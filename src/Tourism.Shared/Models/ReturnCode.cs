using System.ComponentModel;

namespace Tourism.Shared.Models;

public enum ReturnCode
{
    SUCCESS,
    BADREQUEST,
    EXCEPTION,
    [Description("Request invalid")]
    REQUEST_INVALID,
    [Description("Job title not found !")]
    JOB_TITLE_NOT_FOUND,
    DEPARTMENT_NOT_FOUND,
    DEPARTMENT_INVALID,
    EMPLOYEE_INVALID,
    JOB_POSITION_NOT_FOUND,
    EMPLOYEE_NOT_FOUND,
    EFFECTIVE_DONT_GREATER_THAN_EXPIRATION_DATE,
    EMAIL_INVALID,
    CATALOG_NOT_FOUND
}
