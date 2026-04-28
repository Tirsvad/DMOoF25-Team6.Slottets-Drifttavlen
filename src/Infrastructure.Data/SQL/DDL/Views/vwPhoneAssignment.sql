-- ============================================================
-- View: vwPhoneAssignment
-- Description: Provides a read-optimized view of phone assignments
--              joined with caregiver (user) information for the
--              current active shift. Used by the Dashboard PhoneList.
-- CrossReference: UC-005.ERD UC-005.DCD
-- Author: Team 6
-- Date: 2026-04-28
-- Version: 0001
-- ============================================================

CREATE OR REPLACE VIEW vwPhoneAssignment AS
    -- Join PhoneAssignments with AspNetUsers to resolve CaregiverId to UserName
    SELECT
        pa.Id                   AS Id,
        pa.PhoneNumber          AS PhoneNumber,
        pa.ShiftType            AS ShiftType,
        pa.CaregiverId          AS CaregiverId,
        u.UserName              AS CaregiverName
    FROM PhoneAssignments pa
    INNER JOIN AspNetUsers u ON pa.CaregiverId = u.Id;
