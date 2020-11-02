using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Taxi_db.Model;

namespace Taxi_db.Data
{
    public partial class TaxiContext : DbContext
    {
        public TaxiContext()
        {
        }

        public TaxiContext(DbContextOptions<TaxiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Автомобили> Автомобили { get; set; }
        public virtual DbSet<Вызовы> Вызовы { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<ДополнительныеУслуги> ДополнительныеУслуги { get; set; }
        public virtual DbSet<Марки> Марки { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<Тарифы> Тарифы { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=Taxi.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Автомобили>(entity =>
            {
                entity.HasKey(e => e.КодАвтомобиля);

                entity.Property(e => e.КодАвтомобиля)
                    .HasColumnName("Код_автомобиля")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ГодВыпуска)
                    .IsRequired()
                    .HasColumnName("Год_выпуска")
                    .HasColumnType("DATE");

                entity.Property(e => e.ДатаПоследнегоТо)
                    .IsRequired()
                    .HasColumnName("Дата_последнего_ТО")
                    .HasColumnType("DATE");

                entity.Property(e => e.КодМарки)
                    .HasColumnName("Код_марки")
                    .HasColumnType("INT");

                entity.Property(e => e.НомерДвигателя)
                    .IsRequired()
                    .HasColumnName("Номер_двигателя")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.НомерКузова)
                    .IsRequired()
                    .HasColumnName("Номер_кузова")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.Пробег).HasColumnType("FLOAT");

                entity.Property(e => e.РегистрационныйНомер)
                    .IsRequired()
                    .HasColumnName("Регистрационный_номер")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.СпециальныеОтметки)
                    .IsRequired()
                    .HasColumnName("Специальные_отметки")
                    .HasColumnType("CHAR(5)");

                entity.HasOne(d => d.КодМаркиNavigation)
                    .WithMany(p => p.Автомобили)
                    .HasForeignKey(d => d.КодМарки)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Вызовы>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Время)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.Дата)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.КодАвтомобиля)
                    .HasColumnName("Код_автомобиля")
                    .HasColumnType("INT");

                entity.Property(e => e.КодСотрудника)
                    .HasColumnName("Код_сотрудника")
                    .HasColumnType("INT");

                entity.Property(e => e.КодТарифа)
                    .HasColumnName("Код_тарифа")
                    .HasColumnType("INT");

                entity.Property(e => e.КодУслуги)
                    .HasColumnName("Код_услуги")
                    .HasColumnType("INT");

                entity.Property(e => e.Куда)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Откуда)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Телефон)
                    .IsRequired()
                    .HasColumnType("VARCHAR(15)");

                entity.HasOne(d => d.КодАвтомобиляNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.КодАвтомобиля)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодСотрудникаNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.КодСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодТарифаNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.КодТарифа)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодУслугиNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.КодУслуги)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.КодДолжности);

                entity.Property(e => e.КодДолжности)
                    .HasColumnName("Код_должности")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Обязанности)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Оклад).HasColumnType("FLOAT");

                entity.Property(e => e.Требования)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<ДополнительныеУслуги>(entity =>
            {
                entity.HasKey(e => e.КодУслуги);

                entity.ToTable("Дополнительные_услуги");

                entity.Property(e => e.КодУслуги)
                    .HasColumnName("Код_услуги")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Описание)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Стоимость).HasColumnType("FLOAT");
            });

            modelBuilder.Entity<Марки>(entity =>
            {
                entity.HasKey(e => e.КодМарки);

                entity.Property(e => e.КодМарки)
                    .HasColumnName("Код_марки")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnType("VARCHAR(30)");

                entity.Property(e => e.Специфика)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Стоимость).HasColumnType("FLOAT");

                entity.Property(e => e.ТехническиеХарактеристики)
                    .IsRequired()
                    .HasColumnName("Технические_характеристики")
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.КодСотрудника);

                entity.Property(e => e.КодСотрудника)
                    .HasColumnName("Код_сотрудника")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Адрес)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Возраст)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.КодАвтомобиля)
                    .HasColumnName("Код_автомобиля")
                    .HasColumnType("INT");

                entity.Property(e => e.КодДолжности)
                    .HasColumnName("Код_должности")
                    .HasColumnType("INT");

                entity.Property(e => e.ПаспортныеДанные)
                    .IsRequired()
                    .HasColumnName("Паспортные_данные")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Пол)
                    .IsRequired()
                    .HasColumnType("CHAR(3)");

                entity.Property(e => e.Телефон)
                    .IsRequired()
                    .HasColumnType("VARCHAR(15)");

                entity.Property(e => e.Фио)
                    .IsRequired()
                    .HasColumnName("ФИО")
                    .HasColumnType("VARCHAR(100)");

                entity.HasOne(d => d.КодАвтомобиляNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодАвтомобиля)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодДолжностиNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодДолжности)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Тарифы>(entity =>
            {
                entity.HasKey(e => e.КодТарифа);

                entity.Property(e => e.КодТарифа)
                    .HasColumnName("Код_тарифа")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Описание)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Стоимость).HasColumnType("FLOAT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
