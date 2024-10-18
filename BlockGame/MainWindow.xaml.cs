using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows;

namespace BlockGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IsAdministrator())
                {
                    RunAsAdmin();
                }

                // Путь к файлу hosts
                string filePath = @"C:\Windows\system32\drivers\etc\hosts";

                // Удаление файла, если он существует
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Загрузка данных с GitHub
                string url = "https://raw.githubusercontent.com/bibonuwu/Bibon/main/blocked_sites.txt"; // Укажите ваш URL к файлу на GitHub
                string content = await DownloadBlockedSitesAsync(url);

                // Создание нового файла и запись в него
                File.WriteAllText(filePath, content + Environment.NewLine);

                // Очистка DNS-кэша
                FlushDNS();

                MessageBox.Show("Файл успешно обновлен и DNS-кэш очищен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Функция для загрузки данных с GitHub
        private async Task<string> DownloadBlockedSitesAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                    return string.Empty;
                }
            }
        }
        private void FlushDNS()
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "ipconfig",
                    Arguments = "/flushdns",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(processInfo);
                process.WaitForExit();

                MessageBox.Show("DNS-кэш успешно очищен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при очистке DNS-кэша: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RunAsAdmin()
        {
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Verb = "runas"
            };

            try
            {
                Process.Start(processInfo);
                Application.Current.Shutdown();
            }
            catch (Exception)
            {
                MessageBox.Show("Запуск от имени администратора был отменен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteHostsFile(object sender, RoutedEventArgs e)
        {
            string hostsPath = @"C:\Windows\system32\drivers\etc\hosts";

            if (!IsAdministrator())
            {
                // Перезапуск приложения с правами администратора
                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = Process.GetCurrentProcess().MainModule.FileName,
                    Verb = "runas"
                };
                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
                Application.Current.Shutdown();
                return;
            }

            try
            {
                if (File.Exists(hostsPath))
                {
                    File.Delete(hostsPath);
                    MessageBox.Show("Файл hosts успешно удален.");
                }
                else
                {
                    MessageBox.Show("Файл hosts не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении файла: {ex.Message}");
            }
        }
    }
}
