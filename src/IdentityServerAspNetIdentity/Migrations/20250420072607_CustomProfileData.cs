﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerAspNetIdentity.Migrations
{
    /// <inheritdoc />
    public partial class CustomProfileData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoutiteColor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoutiteColor",
                table: "AspNetUsers");
        }
    }
}
