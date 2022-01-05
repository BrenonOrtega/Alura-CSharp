namespace HangfireCron.Api.Configurations
{
    public class CelcoinConsultOptions
    {
        private int _consultTime;
        public TimeSpan ConsultTimeInSeconds { get => TimeSpan.FromSeconds(_consultTime * 100); }
        public TimeSpan ConsultTimeInMinutes { get => TimeSpan.FromMinutes(_consultTime); }
        public TimeSpan ConsultTimeInHours { get => TimeSpan.FromHours(_consultTime / 60); }

        public TimeSpan RetryConsultInterval { get; set; } = TimeSpan.FromSeconds(1);

        public CelcoinConsultOptions()
        {
            _consultTime = 30;
        }
    }
}