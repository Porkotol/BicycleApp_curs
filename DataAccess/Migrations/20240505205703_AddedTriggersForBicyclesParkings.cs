using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedTriggersForBicyclesParkings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER bicycles_AFTER_INSERT AFTER INSERT ON bicycles
            FOR EACH ROW
            BEGIN
                DECLARE park_id INT;
                
                -- Получаем ID парковки, на которую ссылается новый велосипед
                SELECT Parking_Id INTO park_id FROM bicycles WHERE Id = NEW.Id;
                
                -- Обновляем количество велосипедов на парковке
                UPDATE parkings
                SET CurrentBicyclesAmount = (
                    SELECT COUNT(*) FROM bicycles WHERE Parking_Id = park_id
                )
                WHERE Id = park_id;
            END
            ");


            migrationBuilder.Sql(@"
            CREATE TRIGGER after_delete_bicycle AFTER DELETE ON bicycles
            FOR EACH ROW
            BEGIN
                DECLARE park_id INT;
                DECLARE bicycle_count INT;
                
                -- Отримуємо Parking_Id видаленого велосипеда
                SET park_id = OLD.Parking_Id;
                
                -- Знаходимо кількість велосипедів, що залишилися в даній парковці
                SELECT COUNT(*) INTO bicycle_count FROM bicycles WHERE Parking_Id = park_id;
                
                -- Оновлюємо кількість велосипедів у парковці
                UPDATE parkings SET CurrentBicyclesAmount = bicycle_count WHERE Id = park_id;
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS bicycles_AFTER_INSERT");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS after_delete_bicycle");
        }
    }
}
