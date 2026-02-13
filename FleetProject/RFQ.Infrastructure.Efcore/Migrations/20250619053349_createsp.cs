using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />

    public partial class createsp : Migration
    {
        private static readonly string spUP_GetAllVehicleCategory = @"
                    ALTER PROCEDURE [dbo].[GetAllVehicleCategory]
                    AS
                    BEGIN
                        SELECT 
                            im.InternalMasterId,
                            im.InternalMasterTypeId,
                            im.InternalMasterName
                        FROM com_mst_internal_master im
                        JOIN com_mst_internal_master_type imt
                            ON im.InternalMasterTypeId = imt.MaterTypeId
                        WHERE imt.MasterTypeName = 'VEHICLE_CATEGORY';
                    END;
                    ";

        private static readonly string spUP_GetAllVehicleListpUP = @"
            ALTER PROCEDURE [dbo].[sp_GetAllVehicleList]
                @StatusId INT = 30,
                @PageNumber INT = 1,
                @PageSize INT = 10,
                @SearchTerm VARCHAR(100) = NULL,
                @SortColumn VARCHAR(50) = NULL,
                @SortDirection VARCHAR(4) = NULL
            AS
            BEGIN
                SET NOCOUNT ON;
            
                -- Set default sort column/direction
                IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
                    SET @SortColumn = 'UpdatedOn';
            
                IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
                    SET @SortDirection = 'DESC';
            
                DECLARE @Sql NVARCHAR(MAX);
                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
            
                -- Build dynamic SQL with filtering
                SET @Sql = '
                ;WITH FilteredData AS (
                    SELECT 
                        v.VehicleId,
                        v.VehicleNo,
                        v.VehicleTypeId,
                        v.OwnerVendorId,
                        v.VehicleCategoryId,
                        v.VehicleCapacity,
                        v.TrackingProviderId,
                        v.VehicleStatus,
                        v.BlacklistStatus,
                        v.RTORegistration,
                        v.RegistrationDate,
                        v.RegdOwner,
                        v.PermanentAddress,
                        v.EngineNo,
                        v.ChassisNo,
                        v.MakeModel,
                        v.PUCExpiryDate,
                        v.FitnessExpiryDate,
                        v.PermitNo,
                        v.PermitExpiryDate,
                        v.Financer,
                        v.OwnerSerialNo,
                        v.NPNo,
                        v.NPExpiryDate,
                        v.InsuranceCo,
                        v.PolicyNo,
                        v.PolicyExpiryDate,
                        v.VerifiedOn,
                        v.GrossWeight,
                        v.UnladenWeight,
                        v.TaxExpiryDate,
                        v.LinkId,
                        v.StatusId,
                        v.CreatedBy,
                        v.CreatedOn,
                        v.UpdatedBy,
                        v.UpdatedOn
                    FROM dbo.com_mst_vehicle v
                    WHERE 
                        v.StatusId = @StatusId
                        AND (
                            @SearchTerm IS NULL OR @SearchTerm = ''''
                            OR LOWER(v.VehicleNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(v.RegdOwner) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(v.EngineNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(v.ChassisNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(v.PolicyNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        )
                )
                SELECT *, COUNT(*) OVER() AS TotalCount
                FROM FilteredData
                ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY;
                ';
            
                -- Execute dynamic SQL safely
                EXEC sp_executesql 
                    @Sql,
                    N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
                    @StatusId = @StatusId,
                    @SearchTerm = @SearchTerm,
                    @Offset = @Offset,
                    @PageSize = @PageSize;
            END;
            ";

        private static readonly string spUP_GetComMstItemList = @"
            ALTER PROCEDURE [dbo].[sp_GetComMstItemList]
                @StatusId INT,
                @PageNumber INT = 1,
                @PageSize INT = 10,
                @SearchTerm VARCHAR(100) = NULL,
                @SortColumn VARCHAR(50) = NULL,
                @SortDirection VARCHAR(4) = NULL
            AS
            BEGIN
                SET NOCOUNT ON;
            
                -- Default sorting
                IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
                    SET @SortColumn = 'CreatedOn';
            
                IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
                    SET @SortDirection = 'DESC';
            
                DECLARE @Sql NVARCHAR(MAX);
                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
            
                SET @Sql = '
                ;WITH FilteredData AS (
                    SELECT 
                        mi.ItemId,
                        c.CompanyName,
                        mi.ItemName,
                        mi.Description,
                        mi.CompanyId,
                        mi.CreatedBy,
                        mi.CreatedOn,
                        mi.UpdatedBy,
                        mi.UpdatedOn
                    FROM dbo.com_mst_item mi
                    INNER JOIN dbo.com_mst_company c ON mi.CompanyId = c.CompanyId
                    WHERE 
                        mi.StatusId = @StatusId AND (
                            @SearchTerm IS NULL OR @SearchTerm = '''' OR
                            LOWER(mi.ItemName) LIKE ''%'' + LOWER(@SearchTerm) + ''%'' OR
                            LOWER(mi.Description) LIKE ''%'' + LOWER(@SearchTerm) + ''%'' OR
                            LOWER(c.CompanyName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        )
                )
                SELECT *,
                       COUNT(*) OVER() AS TotalCount
                FROM FilteredData
                ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY;
                ';
            
                EXEC sp_executesql 
                    @Sql,
                    N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
                    @StatusId = @StatusId,
                    @SearchTerm = @SearchTerm,
                    @Offset = @Offset,
                    @PageSize = @PageSize;
            END;
            ";

        private static readonly string spUP_GetCompanyConfigurationList = @"
            ALTER PROCEDURE [dbo].[sp_GetCompanyConfigurationList]
                @StatusId INT,
                @PageNumber INT = 1,
                @PageSize INT = 10,
                @SearchTerm VARCHAR(100) = NULL,
                @SortColumn VARCHAR(50) = NULL,
                @SortDirection VARCHAR(4) = NULL
            AS
            BEGIN
                SET NOCOUNT ON;
            
                -- Set default sorting
                IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
                    SET @SortColumn = 'CompanyConfigId';
            
                IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
                    SET @SortDirection = 'DESC';
            
                DECLARE @Sql NVARCHAR(MAX);
                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
            
                SET @Sql = '
                ;WITH FilteredData AS (
                    SELECT 
                        c.CompanyConfigId,
                        c.CompanyId,
                        c.SMSProvider,
                        c.SMSAuthKey,
                        c.WhatsAppProvider,
                        c.WhatsAppAuthKey,
                        c.SMTPHost,
                        c.SMTPPort,
                        c.SMTPUsername,
                        c.SMTPPassword
                    FROM 
                        dbo.com_mst_company_config c
                    WHERE 
                        (@StatusId IS NULL OR c.CompanyId IN (
                            SELECT CompanyId FROM dbo.com_mst_company WHERE StatusId = @StatusId
                        )) AND (
                            @SearchTerm IS NULL OR @SearchTerm = '''' OR
                            LOWER(CONVERT(VARCHAR, c.CompanyId)) LIKE ''%'' + LOWER(@SearchTerm) + ''%'' OR
                            LOWER(c.SMSProvider) LIKE ''%'' + LOWER(@SearchTerm) + ''%'' OR
                            LOWER(c.WhatsAppProvider) LIKE ''%'' + LOWER(@SearchTerm) + ''%'' OR
                            LOWER(c.SMTPHost) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        )
                )
                SELECT *, 
                       COUNT(*) OVER() AS TotalCount
                FROM FilteredData
                ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY;
                ';
            
                EXEC sp_executesql 
                    @Sql,
                    N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
                    @StatusId = @StatusId,
                    @SearchTerm = @SearchTerm,
                    @Offset = @Offset,
                    @PageSize = @PageSize;
            END;
            ";

        private static readonly string spUP_GetCompanyList = @"
ALTER PROCEDURE [dbo].[sp_GetCompanyList]
    @StatusId INT,
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @SearchTerm VARCHAR(100) = NULL,
    @SortColumn VARCHAR(50) = NULL,
    @SortDirection VARCHAR(4) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Default sorting
    IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
        SET @SortColumn = 'CompanyId';

    IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
        SET @SortDirection = 'ASC';

    DECLARE @Sql NVARCHAR(MAX);
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    -- Dynamic SQL build
    SET @Sql = '
    ;WITH FilteredData AS (
        SELECT 
            CompanyId,
            CompanyName,
            CompanyTypeId,
            AddressLine,
            CityId,
            PinCode,
            ContactPerson,
            ContactNo,
            MobNo,
            WhatsAppNo,
            Email,
            PANNo,
            GSTNo,
            LogoImage,
            ParentCompanyId,
            LinkId,
            StatusId,
            CreatedBy,
            CreatedOn,
            UpdatedBy,
            UpdatedOn
        FROM com_mst_company
        WHERE 
            StatusId = @StatusId 
            AND CompanyTypeId = 3
            AND (
                @SearchTerm IS NULL OR @SearchTerm = ''''
                OR LOWER(CompanyName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(AddressLine) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(ContactPerson) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(Email) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
            )
    )
    SELECT *,
           COUNT(*) OVER() AS TotalCount
    FROM FilteredData
    ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
    ';

    -- Execute the dynamic SQL safely
    EXEC sp_executesql 
        @Sql,
        N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
        @StatusId = @StatusId,
        @SearchTerm = @SearchTerm,
        @Offset = @Offset,
        @PageSize = @PageSize;
END;
";

        private static readonly string spUP_GetCustomerList = @"
            ALTER PROCEDURE [dbo].[sp_GetCustomerList]
                @StatusId INT,
                @PageNumber INT = 1,
                @PageSize INT = 10,
                @SearchTerm VARCHAR(100) = NULL,
                @SortColumn VARCHAR(50) = NULL,
                @SortDirection VARCHAR(4) = NULL
            AS
            BEGIN
                SET NOCOUNT ON;
            
                IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
                    SET @SortColumn = 'UpdatedOn';
            
                IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
                    SET @SortDirection = 'DESC';
            
                DECLARE @Sql NVARCHAR(MAX);
                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
            
                SET @Sql = '
                ;WITH FilteredData AS (
                    SELECT 
                        mp.PartyId,
                        mp.CompanyId,
                        mp.PartyTypeId,
                        mp.PartyName,
                        mp.PartyCategoryId,
                        mp.AddressLine,
                        mp.CityId,
                        mp.PinCode,
                        mp.ContactPerson,
                        mp.ContactNo,
                        mp.MobNo,
                        mp.WhatsAppNo,
                        mp.Email,
                        mp.PANNo,
                        mp.GSTNo,
                        mp.LegalName,
                        mp.TradeName,
                        mp.TypeOfBusiness,
                        mp.AadharVerified,
                        mp.GSTStatus,
                        mp.GSTVarifiedOn,
                        mp.PANStatus,
                        mp.PANLinkedWithAdhar,
                        mp.PANVerifiedOn,
                        mp.LinkId,
                        mp.StatusId,
                        mp.CreatedBy,
                        mp.CreatedOn,
                        mp.UpdatedBy,
                        mp.UpdatedOn
                    FROM com_mst_party mp
                    WHERE 
                        mp.StatusId = @StatusId 
                        AND mp.PartyTypeId = 6
                        AND (
                            @SearchTerm IS NULL OR @SearchTerm = ''''
                            OR LOWER(mp.PartyName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(mp.ContactPerson) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(mp.MobNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(mp.Email) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(mp.AddressLine) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        )
                )
                SELECT *,
                       COUNT(*) OVER() AS TotalCount
                FROM FilteredData
                ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY;
                ';
            
                EXEC sp_executesql 
                    @Sql,
                    N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
                    @StatusId = @StatusId,
                    @SearchTerm = @SearchTerm,
                    @Offset = @Offset,
                    @PageSize = @PageSize;
            END;
            ";

        private static readonly string spUP_GetDriverList = @"
            ALTER PROCEDURE [dbo].[sp_GetDriverList]
                @StatusId INT,
                @PageNumber INT = 1,
                @PageSize INT = 10,
                @SearchTerm VARCHAR(100) = NULL,
                @SortColumn VARCHAR(50) = NULL,
                @SortDirection VARCHAR(4) = NULL
            AS
            BEGIN
                SET NOCOUNT ON;
            
                IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
                    SET @SortColumn = 'DriverId';
            
                IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
                    SET @SortDirection = 'ASC';
            
                DECLARE @Sql NVARCHAR(MAX);
                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
            
                SET @Sql = '
                ;WITH FilteredData AS (
                    SELECT 
                        d.DriverId,
                        d.DriverTypeId,
                        d.DriverName,
                        d.DriverCode,
                        d.LicenseNo,
                        d.DateOfBirth,
                        d.LicenseIssueDate,
                        d.LicenseIssueCityId,
                        d.LicenseExpDate,
                        d.MobNo,
                        d.WhatsAppNo,
                        d.AddressLine,
                        d.CityId,
                        d.PinCode,
                        d.DriverImagePath,
                        d.LinkId,
                        d.StatusId,
                        d.CreatedBy,
                        d.CreatedOn,
                        d.UpdatedBy,
                        d.UpdatedOn
                    FROM com_mst_driver d
                    WHERE 
                        d.StatusId = @StatusId
                        AND (
                            @SearchTerm IS NULL OR @SearchTerm = ''''
                            OR LOWER(d.DriverName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(d.DriverCode) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(d.LicenseNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(d.MobNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(d.AddressLine) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        )
                )
                SELECT *,
                       COUNT(*) OVER() AS TotalCount
                FROM FilteredData
                ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY;
                ';
            
                EXEC sp_executesql 
                    @Sql,
                    N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
                    @StatusId = @StatusId,
                    @SearchTerm = @SearchTerm,
                    @Offset = @Offset,
                    @PageSize = @PageSize;
            END;
            ";

        private static readonly string spUP_GetFranchiseList = @"
            ALTER PROCEDURE [dbo].[sp_GetFranchiseList]
                @StatusId INT,
                @PageNumber INT = 1,
                @PageSize INT = 10,
                @SearchTerm VARCHAR(100) = NULL,
                @SortColumn VARCHAR(50) = NULL,
                @SortDirection VARCHAR(4) = NULL
            AS
            BEGIN
                SET NOCOUNT ON;
            
                IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
                    SET @SortColumn = 'CompanyId';
            
                IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
                    SET @SortDirection = 'ASC';
            
                DECLARE @Sql NVARCHAR(MAX);
                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
            
                SET @Sql = '
                ;WITH FilteredData AS (
                    SELECT
                        CompanyId,
                        CompanyName,
                        CompanyTypeId,
                        AddressLine,
                        CityId,
                        PinCode,
                        ContactPerson,
                        ContactNo,
                        MobNo,
                        WhatsAppNo,
                        Email,
                        PANNo,
                        GSTNo,
                        LogoImage,
                        ParentCompanyId,
                        LinkId,
                        StatusId,
                        CreatedBy,
                        CreatedOn,
                        UpdatedBy,
                        UpdatedOn
                    FROM com_mst_company
                    WHERE 
                        StatusId = @StatusId 
                        AND CompanyTypeId = 2
                        AND (
                            @SearchTerm IS NULL OR @SearchTerm = ''''
                            OR LOWER(CompanyName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(AddressLine) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(CityId) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(ContactPerson) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                            OR LOWER(Email) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        )
                )
                SELECT *,
                       COUNT(*) OVER() AS TotalCount
                FROM FilteredData
                ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY;
                ';
            
                EXEC sp_executesql 
                    @Sql,
                    N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
                    @StatusId = @StatusId,
                    @SearchTerm = @SearchTerm,
                    @Offset = @Offset,
                    @PageSize = @PageSize;
            END;
            ";

        private static readonly string spUP_GetLocationList = @"
        ALTER PROCEDURE [dbo].[sp_GetLocationList]
            @StatusId INT,
            @PageNumber INT = 1,
            @PageSize INT = 10,
            @SearchTerm VARCHAR(100) = NULL,
            @SortColumn VARCHAR(50) = NULL,
            @SortDirection VARCHAR(4) = NULL
        AS
        BEGIN
            SET NOCOUNT ON;
        
            IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
                SET @SortColumn = 'LocationId';
        
            IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
                SET @SortDirection = 'ASC';
        
            DECLARE @Sql NVARCHAR(MAX);
            DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
        
            SET @Sql = '
            ;WITH FilteredData AS (
                SELECT
                    l.LocationId,
                    l.CompanyId,
                    l.CityId,
                    ci.CityName AS City,
                    l.LocationName,
                    l.AddressLine,
                    l.PinCode,
                    l.ContactPerson,
                    l.ContactNo,
                    l.MobNo,
                    l.WhatsAppNo,
                    l.Email,
                    l.LinkId,
                    l.StatusId,
                    l.CreatedBy,
                    l.CreatedOn,
                    l.UpdatedBy,
                    l.UpdatedOn
                FROM 
                    com_mst_location l
                INNER JOIN 
                    com_mst_city ci ON l.CityId = ci.CityId
                WHERE 
                    l.StatusId = @StatusId
                    AND (
                        @SearchTerm IS NULL OR @SearchTerm = ''''
                        OR LOWER(l.LocationName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        OR LOWER(l.AddressLine) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        OR LOWER(l.ContactPerson) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        OR LOWER(l.Email) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                        OR LOWER(ci.CityName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                    )
            )
            SELECT *,
                   COUNT(*) OVER() AS TotalCount
            FROM FilteredData
            ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY;
            ';
        
            EXEC sp_executesql 
                @Sql,
                N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
                @StatusId = @StatusId,
                @SearchTerm = @SearchTerm,
                @Offset = @Offset,
                @PageSize = @PageSize;
        END;
        ";

        private static readonly string spUP_GetPagedData = @"
            ALTER PROCEDURE [dbo].[sp_GetPagedData]
                @ProcedureName NVARCHAR(255),
                @Params NVARCHAR(MAX)
            AS
            BEGIN
                SET NOCOUNT ON;
            
                DECLARE @Sql NVARCHAR(MAX);
            
                -- Build dynamic EXEC SQL
                SET @Sql = N'EXEC ' + QUOTENAME(@ProcedureName) + N' ' + @Params;
            
                -- Debugging option (remove in production)
                -- select @Sql return ;
            
                EXEC sp_executesql @Sql;
            END;
            ";

        private static readonly string spUP_GetUserList = @"
ALTER PROCEDURE [dbo].[sp_GetUserList]
    @StatusId INT,
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @SearchTerm VARCHAR(100) = NULL,
    @SortColumn VARCHAR(50) = NULL,
    @SortDirection VARCHAR(4) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
        SET @SortColumn = 'UserId';

    IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
        SET @SortDirection = 'ASC';

    DECLARE @Sql NVARCHAR(MAX);
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    SET @Sql = '
    ;WITH FilteredData AS (
        SELECT
            u.UserId,
            u.CompanyId,
            c.CompanyName AS Company,
            u.LocationId,
            l.LocationName AS Location,
            u.ProfileId,
            u.PersonName,
            u.LoginId,
            u.Password,
            u.EmailId,
            u.MobileNo,
            u.StatusId,
            u.CreatedBy,
            u.CreatedOn,
            u.UpdatedBy,
            u.UpdatedOn
        FROM 
            com_mst_user u
        INNER JOIN 
            com_mst_company c ON u.CompanyId = c.CompanyId
        INNER JOIN 
            com_mst_location l ON u.LocationId = l.LocationId
        WHERE 
            u.StatusId = @StatusId
            AND (
                @SearchTerm IS NULL OR @SearchTerm = ''''
                OR LOWER(u.PersonName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(c.CompanyName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(l.LocationName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(u.LoginId) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(u.EmailId) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
            )
    )
    SELECT *,
           COUNT(*) OVER() AS TotalCount
    FROM FilteredData
    ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
    ';

    EXEC sp_executesql 
        @Sql,
        N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
        @StatusId = @StatusId,
        @SearchTerm = @SearchTerm,
        @Offset = @Offset,
        @PageSize = @PageSize;
END;
";

        private static readonly string spUP_GetVendorList = @"
ALTER PROCEDURE [dbo].[sp_GetVendorList]
    @StatusId INT,
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @SearchTerm VARCHAR(100) = NULL,
    @SortColumn VARCHAR(50) = NULL,
    @SortDirection VARCHAR(4) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @SortColumn IS NULL OR LTRIM(RTRIM(@SortColumn)) = ''
        SET @SortColumn = 'UpdatedOn';

    IF @SortDirection IS NULL OR UPPER(@SortDirection) NOT IN ('ASC', 'DESC')
        SET @SortDirection = 'DESC';

    DECLARE @Sql NVARCHAR(MAX);
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    SET @Sql = '
    ;WITH FilteredData AS (
        SELECT 
            mp.PartyId,
            mp.CompanyId,
            mp.PartyTypeId,
            mp.PartyName,
            mp.PartyCategoryId,
            mp.AddressLine,
            mp.CityId,
            mp.PinCode,
            mp.ContactPerson,
            mp.ContactNo,
            mp.MobNo,
            mp.WhatsAppNo,
            mp.Email,
            mp.PANNo,
            mp.GSTNo,
            mp.LegalName,
            mp.TradeName,
            mp.TypeOfBusiness,
            mp.AadharVerified,
            mp.GSTStatus,
            mp.GSTVarifiedOn,
            mp.PANStatus,
            mp.PANLinkedWithAdhar,
            mp.PANVerifiedOn,
            mp.LinkId,
            mp.StatusId,
            mp.CreatedBy,
            mp.CreatedOn,
            mp.UpdatedBy,
            mp.UpdatedOn
        FROM com_mst_party mp
        WHERE 
            mp.StatusId = @StatusId 
            AND mp.PartyTypeId = 5
            AND (
                @SearchTerm IS NULL OR @SearchTerm = ''''
                OR LOWER(mp.PartyName) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(mp.AddressLine) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(mp.ContactPerson) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(mp.Email) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(mp.GSTNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
                OR LOWER(mp.PANNo) LIKE ''%'' + LOWER(@SearchTerm) + ''%''
            )
    )
    SELECT *,
           COUNT(*) OVER() AS TotalCount
    FROM FilteredData
    ORDER BY ' + QUOTENAME(@SortColumn) + ' ' + @SortDirection + '
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
    ';

    EXEC sp_executesql 
        @Sql,
        N''@StatusId INT, @SearchTerm VARCHAR(100), @Offset INT, @PageSize INT'',
        @StatusId = @StatusId,
        @SearchTerm = @SearchTerm,
        @Offset = @Offset,
        @PageSize = @PageSize;
END;
";

        private static readonly string spUP_MenuList = @"
ALTER PROCEDURE [dbo].[sp_MenuList]  
(  
    @ProfileId INT   
)  
AS  
BEGIN  
    SELECT 
        LG.LinkGroupId,
        LG.LinkGroupName,
        LG.LinkIcon AS LinkGroupIcon,
        LI.LinkId,
        LI.LinkName,
        LI.ListingQuery,
        LI.LinkIcon,
        LI.SequenceNo,
        LI.LinkUrl,
        LI.AddUrl,
        LI.EditUrl,
        LI.CancelUrl,
        LI.StatusId
    FROM 
        com_mst_link_item LI WITH (NOLOCK)
    INNER JOIN 
        com_mst_profile_right PR WITH (NOLOCK) ON LI.LinkId = PR.LinkId AND PR.ProfileId = @ProfileId
    INNER JOIN 
        com_mst_link_group LG WITH (NOLOCK) ON LI.LinkGroupId = LG.LinkGroupId
    WHERE 
        LI.StatusId = 30
    ORDER BY 
        LG.SequenceNo, LI.SequenceNo
END;
";

        private static readonly string GetNextRfqNo = @"ALTER   PROCEDURE [dbo].[GetNextRfqNo]
                    AS
                    BEGIN
                        DECLARE @NextNo INT
                    
                        SELECT @NextNo = ISNULL(MAX(CAST(RfqNo AS INT)), 0) + 1 FROM com_trn_rfq -- Use your actual table name
                    
                        SELECT RIGHT('000000' + CAST(@NextNo AS VARCHAR(6)), 6) AS NextRfqNo
                    END";

        public static readonly string spDown = @"
        DROP PROCEDURE IF EXISTS GetAllVehicleCategory;
        DROP PROCEDURE IF EXISTS sp_GetAllVehicleList;
        DROP PROCEDURE IF EXISTS sp_GetAllVehicleList;
        DROP PROCEDURE IF EXISTS sp_GetComMstItemList;
        DROP PROCEDURE IF EXISTS sp_GetCompanyConfigurationList;
        DROP PROCEDURE IF EXISTS sp_GetCompanyList;
        DROP PROCEDURE IF EXISTS sp_GetCustomerList;
        DROP PROCEDURE IF EXISTS sp_GetDriverList;
        DROP PROCEDURE IF EXISTS sp_GetFranchiseList;
        DROP PROCEDURE IF EXISTS sp_GetLocationList;
        DROP PROCEDURE IF EXISTS sp_GetPagedData;
        DROP PROCEDURE IF EXISTS sp_GetUserList;
        DROP PROCEDURE IF EXISTS sp_GetVendorList;
        DROP PROCEDURE IF EXISTS sp_MenuList;
        DROP PROCEDURE IF EXISTS GetNextRfqNo;
    ";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(spUP_GetAllVehicleCategory);
            migrationBuilder.Sql(spUP_GetAllVehicleListpUP);
            migrationBuilder.Sql(spUP_GetComMstItemList);
            migrationBuilder.Sql(spUP_GetCompanyConfigurationList);
            migrationBuilder.Sql(spUP_GetCompanyList);
            migrationBuilder.Sql(spUP_GetCustomerList);
            migrationBuilder.Sql(spUP_GetDriverList);
            migrationBuilder.Sql(spUP_GetFranchiseList);
            migrationBuilder.Sql(spUP_GetLocationList);
            migrationBuilder.Sql(spUP_GetPagedData);
            migrationBuilder.Sql(spUP_GetUserList);
            migrationBuilder.Sql(spUP_GetVendorList);
            migrationBuilder.Sql(spUP_MenuList);
            migrationBuilder.Sql(GetNextRfqNo);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(spDown);
        }
    }
}
