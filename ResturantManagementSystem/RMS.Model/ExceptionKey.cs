namespace RMS.Model
{
    public enum ExceptionKey
    {
        Success=0,
        CriticalCodeException=1,
        DataNotFoundException=2,
        CuisineNotCreatedExcepton=20,       
        CuisineAlreadyExist = 21,
        CuisineDoesNotExist = 22,
        CourseNotCreatedExcepton = 30,
        CourseAlreadyExist = 31,
        CourseDoesNotExist = 32,
        MenuNotCreatedExcepton = 40,
        MenuAlreadyExist = 41,
        MenuDoesNotExist = 42,
        Failure=12
    }
}
