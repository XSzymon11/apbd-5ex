using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFHomework.Migrations
{
    /// <inheritdoc />
    public partial class InitTableMedicament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "A non-steroidal anti-inflammatory drug (NSAID) used for pain relief and to reduce fever", "Ibuprofen", "Analgesic" },
                    { 2, "A pain reliever and fever reducer with no significant anti-inflammatory properties", "Paracetamol", "Analgesic" },
                    { 3, "A β-lactam antibiotic used to treat a variety of bacterial infections", "Amoxicillin", "Antibiotic" },
                    { 4, " An ACE inhibitor used to treat high blood pressure and heart failure", "Lisinopril", "Antihypertensive" },
                    { 5, "A proton pump inhibitor used to treat acid reflux and stomach ulcers", "Omeprazole", "Gastroprotective" },
                    { 6, "An oral medication used to control blood sugar levels in people with type 2 diabetes", "Metformin", "Antidiabetic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 6);
        }
    }
}
