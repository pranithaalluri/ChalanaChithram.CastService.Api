using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChalanaChithram.CastService.Api.Migrations
{
    /// <inheritdoc />
    public partial class DataTypeChangeToByteUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "People");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "People",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "People",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
