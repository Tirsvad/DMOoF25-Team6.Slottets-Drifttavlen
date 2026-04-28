// Copyright (c) 2026 Team6. All rights reserved.
// No warranty, explicit or implicit, provided.

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class AddPhoneAssignmentView : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Create the vwPhoneAssignment view
        // Source: SQL/DDL/Views/vwPhoneAssignment.sql
        migrationBuilder.Sql(@"
            CREATE OR REPLACE VIEW vwPhoneAssignment AS
                SELECT
                    pa.Id           AS Id,
                    pa.PhoneNumber  AS PhoneNumber,
                    pa.ShiftType    AS ShiftType,
                    pa.CaregiverId  AS CaregiverId,
                    u.UserName      AS CaregiverName
                FROM PhoneAssignments pa
                INNER JOIN AspNetUsers u ON pa.CaregiverId = u.Id;
        ");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Drop the vwPhoneAssignment view
        migrationBuilder.Sql("DROP VIEW IF EXISTS vwPhoneAssignment;");
    }
}
