namespace AnimalApp.Services
{
    // Простой интерфейс логгера — можно потом заменить на любой другой
    public interface ILogService
    {
        void Log(string message);
    }
}