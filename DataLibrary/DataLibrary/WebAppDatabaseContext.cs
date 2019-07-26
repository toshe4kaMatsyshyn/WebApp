using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLibrary
{
    public partial class WebAppDatabaseContext : DbContext
    {
        public WebAppDatabaseContext()
        {
        }

        public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<DeliveredBrands> DeliveredBrands { get; set; }
        public virtual DbSet<ProducedBrands> ProducedBrands { get; set; }
        public virtual DbSet<Terminal> Terminal { get; set; }
        public virtual DbSet<TerminalsAndBrands> TerminalsAndBrands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GN3L1JT\\SQLEXPRESS;Database=WebAppDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<DeliveredBrands>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProduceBrandsId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.ProduceBrands)
                    .WithMany(p => p.DeliveredBrands)
                    .HasForeignKey(d => d.ProduceBrandsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveredBrands_ProducedBrands");
            });

            modelBuilder.Entity<ProducedBrands>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.YearOfProduced).HasColumnType("date");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProducedBrands)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProducedBrands_Brands");
            });

            modelBuilder.Entity<Terminal>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<TerminalsAndBrands>(entity =>
            {
                entity.HasKey(e => new { e.ProducedBrandsId, e.TerminalId });

                entity.Property(e => e.ProducedBrandsId).HasMaxLength(20);

                entity.Property(e => e.TerminalId).HasMaxLength(10);

                entity.HasOne(d => d.ProducedBrands)
                    .WithMany(p => p.TerminalsAndBrands)
                    .HasForeignKey(d => d.ProducedBrandsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TerminalsAndBrands_ProducedBrands");

                entity.HasOne(d => d.Terminal)
                    .WithMany(p => p.TerminalsAndBrands)
                    .HasForeignKey(d => d.TerminalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TerminalsAndBrands_Terminal");
            });
        }

        /// <summary>
        /// Добавляет новый бренд, если такого еще не существует
        /// </summary>
        /// <param name="newBrand">Бренд, который пользователь хочет добавить</param>
        /// <returns>Удалось ли добавить новый бренд</returns>
        public bool AddNewBrand(Brands newBrand)
        {
            try
            {
                foreach (Brands brand in Brands)
                    if (brand.Name.StartsWith(newBrand.Name)) return false;
                Brands.Add(newBrand);
                SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        /// <summary>
        /// Добавляет производимый бренд
        /// </summary>
        /// <param name="newProduced">Производимый бренд, который хотим добавить</param>
        /// <returns>
        /// Удалось ли добавить новый производимый бренд
        /// </returns>
        public bool AddNewProducedBrand(ProducedBrands newProduced)
        {
            try
            {
                ProducedBrands.Add(newProduced);
                SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        /// <summary>
        /// Добавляет доставленый бренд
        /// </summary>
        /// <param name="newDelivered">Доставленый бренд, который хотим добавить</param>
        /// <returns>Удалось ли добавить новый доставленый бренд</returns>
        public bool AddNewDeliveredBrand(DeliveredBrands newDelivered)
        {
            try
            {
                var produced = newDelivered.ProduceBrands;
                Entry(produced).Collection("DeliveredBrands").Load();

                //Сохраняем количество произведенных авто для проверки
                //Если хотим продать больше чем произвели продать не получиться 
                int? GeneralSumOfProduced = produced.CountOfProduced;

                foreach (DeliveredBrands delivereds in produced.DeliveredBrands)
                    GeneralSumOfProduced -= delivereds.CountOfDelivered;

                GeneralSumOfProduced -= newDelivered.CountOfDelivered;

                if (GeneralSumOfProduced < 0)
                {
                    return false;
                }

                DeliveredBrands.Add(newDelivered);
                SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }


        /// <summary>
        /// Добавляет новый терминал
        /// </summary>
        /// <param name="newTerminal">Новый терминал, который хотим добавить</param>
        /// <returns>Удалось ли добавить новый терминал</returns>
        public bool AddNewTerminal(Terminal newTerminal)
        {
            try
            {
                foreach (Terminal terminal in Terminal)
                    if (terminal.Name.StartsWith(newTerminal.Name)) return false;
                Terminal.Add(newTerminal);
                SaveChanges();
                return true;
            }
            catch(Exception exc)
            {
                return false;
            }
        }

        /// <summary>
        /// Добавляет производимый бренд к терминалу
        /// </summary>
        /// <param name="produced"></param>
        /// <param name="terminal"></param>
        /// <returns>Удалось ли добавить бренд</returns>
        public bool AddProducedBrandToTerminal(ProducedBrands produced, Terminal terminal)
        {
            try
            {
                TerminalsAndBrands terminalAndBrand = new TerminalsAndBrands(produced, terminal);
                TerminalsAndBrands.Add(terminalAndBrand);
                SaveChanges();
                terminal.ProducedBrands += 1;
                return true;
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                return false;
            }
        }

        /// <summary>
        /// Получение всех брендов, которые есть в определенном терминале
        /// </summary>
        /// <param name="terminal">Терминал, который нас интересует</param>
        /// <returns>Список брендов</returns>
        public List<Brands> GetAllBrandsInTreminal(Terminal terminal)
        {
            List<Brands> brandsInTreminal = new List<Brands>();
            try
            {
                Entry(terminal).Collection("TerminalsAndBrands").Load();
                foreach (TerminalsAndBrands tb in terminal.TerminalsAndBrands)
                {
                    Entry(tb).Reference("ProducedBrands").Load();
                    Entry(tb.ProducedBrands).Reference("Brand").Load();
                    brandsInTreminal.Add(tb.ProducedBrands.Brand);
                }
                return brandsInTreminal;
            }
            catch(Exception exc)
            {
                return brandsInTreminal;
            }
        }

        /// <summary>
        /// Получение всех производимых брендов, которые есть в определенном терминале
        /// </summary>
        /// <param name="terminal">Терминал, который нас интересует</param>
        /// <returns>Список брендов</returns>
        public List<ProducedBrands> GetAllProducedBrandsInTerminal(Terminal terminal)
        {
            List<ProducedBrands> producedBrandsInTerminal = new List<ProducedBrands>();
            try
            {
                Entry(terminal).Collection("TerminalsAndBrands").Load();
                foreach (TerminalsAndBrands tb in terminal.TerminalsAndBrands)
                {
                    Entry(tb).Reference("ProducedBrands").Load();
                    producedBrandsInTerminal.Add(tb.ProducedBrands);
                }
                return producedBrandsInTerminal;
            }
            catch (Exception exc)
            {
                return producedBrandsInTerminal;
            }
        }

        /// <summary>
        /// Получение списка отсортированых терминалов по количеству производимых брендов
        /// </summary>
        /// <returns></returns>
        public List<Terminal> GetSortedTerminals()
        {
            List<Terminal> terminals = new List<Terminal>();
            foreach (Terminal terminal in Terminal)
                terminals.Add(terminal);
            terminals.Sort();
            return terminals;
        }
    }
}

