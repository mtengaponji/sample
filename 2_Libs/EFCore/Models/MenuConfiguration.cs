﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using static ColumnNames;

internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus")
            .HasKey(m => m.MenuId);
        builder.Property(m => m.MenuId)
            .ValueGeneratedOnAdd();
        builder.Property(m => m.Text)
            .HasMaxLength(50);
        builder.Property(m => m.Price)
            .HasColumnType("Money");

        builder.HasOne(m => m.MenuCard)
            .WithMany(c => c.Menus)
            .HasForeignKey(MenuCardId);

        // shadow properties
        builder.Property<bool>(IsDeleted);
        builder.Property<DateTime>(LastUpdated);
        builder.Property<Guid>(RestaurantId);
        // builder.Property<int>(MenuCardId); // created because of HasForeignKey   
    }
}
