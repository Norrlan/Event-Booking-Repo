using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using soft20181_starter.Models;

#nullable disable

namespace soft20181_starter.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(EventAppDbContext))]
    [Migration("20260516133000_UpdateEventFields")]
    public partial class UpdateEventFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "EventDescription");

            migrationBuilder.RenameColumn(
                name: "EventDateTime",
                table: "Events",
                newName: "EventStartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventStartTime",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventEndTime",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Events",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TicketsAvailable",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            // Keep the old EType column in SQLite. The current model no longer uses it,
            // and removing columns in SQLite requires a table rebuild.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsAvailable",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventEndTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventStartTime",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EventDescription",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "EventStartDate",
                table: "Events",
                newName: "EventDateTime");
        }
    }
}
