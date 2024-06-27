﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoUsuario.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "teste",
                table: "Users",
                type: "integer",
                maxLength: 2,
                nullable: false,
                defaultValue: 0);
        }
    }
}