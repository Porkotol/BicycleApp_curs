using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUpdateTriggerForBicyclesParkings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                CREATE DEFINER=`root`@`localhost` TRIGGER `bicycles_AFTER_UPDATE` AFTER UPDATE ON `bicycles` FOR EACH ROW BEGIN
                    DECLARE old_park_id INT;
                    DECLARE new_park_id INT;
                    DECLARE old_bicycle_count INT;
                    DECLARE new_bicycle_count INT;

                    -- Отримуємо Parking_Id старого велосипеда
                    SET old_park_id = OLD.Parking_Id;

                    -- Отримуємо Parking_Id нового велосипеда
                    SET new_park_id = NEW.Parking_Id;

                    -- Обчислюємо кількість велосипедів на старому парковці
                    SELECT COUNT(*) INTO old_bicycle_count FROM bicycles WHERE Parking_Id = old_park_id;

                    -- Обчислюємо кількість велосипедів на новому парковці
                    SELECT COUNT(*) INTO new_bicycle_count FROM bicycles WHERE Parking_Id = new_park_id;

                    -- Оновлюємо кількість велосипедів на старому парковці
                    UPDATE parkings SET CurrentBicyclesAmount = old_bicycle_count WHERE Id = old_park_id;

                    -- Оновлюємо кількість велосипедів на новому парковці
                    UPDATE parkings SET CurrentBicyclesAmount = new_bicycle_count WHERE Id = new_park_id;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS bicycles_AFTER_UPDATE");
        }
    }
}
