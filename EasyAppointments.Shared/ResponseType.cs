namespace EasyAppointments.Data.Repositories
{
    public enum ResponseType
    {
        Success,
        RecordAlreadyExist,
        RowsNotAffected,
        InternalServerError,
        InvalidEmailOrContact,
        InvalidPassword
    }
}
