using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerAspNetIdentity.Migrations
{
    /// <inheritdoc />
    public partial class CustomProfileData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoutiteColor",
                table: "AspNetUsers",
                newName: "FavoriteColor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteColor",
                table: "AspNetUsers",
                newName: "FavoutiteColor");
        }
    }
}
