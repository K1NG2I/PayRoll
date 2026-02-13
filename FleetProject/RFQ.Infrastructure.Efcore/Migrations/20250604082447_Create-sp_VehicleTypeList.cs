using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class Createsp_VehicleTypeList : Migration
    {

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
			CREATE OR ALTER Procedure sp_GetVehicleTypeList   
				@StatusId int = 30,
				@PageNumber int  = 1,
				@PageSize int = 5
				AS 
				BEGIN
			SELECT 
				VehicleTypeId,
				CompanyId,
				VehicleTypeName,
				MinimumKms,
				StatusId,
				CreatedBy,
				CreatedOn,
				UpdatedBy,
				UpdatedOn, 
				COUNT(*) OVER() AS TotalCount
			FROM 
				com_mst_vehicle_type
			WHERE 
				StatusId = @StatusId
			ORDER BY 
				VehicleTypeId
			OFFSET 
				(@PageNumber - 1) * @PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY;
			END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop PROCEDURE sp_GetVehicleTypeList");
        }
    }
}
