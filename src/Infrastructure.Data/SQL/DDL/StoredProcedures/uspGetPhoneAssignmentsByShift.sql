-- ============================================================
-- Stored Procedure: uspGetPhoneAssignmentsByShift
-- Description: Retrieves all phone assignments for a specific
--              shift type, joined with caregiver information.
--              Used by the Dashboard PhoneList.
-- CrossReference: UC-005.ERD UC-005.DCD
-- Author: Team 6
-- Date: 2026-04-28
-- Version: 0001
-- ============================================================

DROP PROCEDURE IF EXISTS uspGetPhoneAssignmentsByShift;

CREATE PROCEDURE uspGetPhoneAssignmentsByShift(
    IN p_ShiftType VARCHAR(50)
)
BEGIN
    -- Retrieve phone assignments filtered by shift type
    SELECT
        pa.Id           AS Id,
        pa.PhoneNumber  AS PhoneNumber,
        pa.ShiftType    AS ShiftType,
        pa.CaregiverId  AS CaregiverId,
        u.UserName      AS CaregiverName
    FROM PhoneAssignments pa
    INNER JOIN AspNetUsers u ON pa.CaregiverId = u.Id
    WHERE pa.ShiftType = p_ShiftType;
END;
