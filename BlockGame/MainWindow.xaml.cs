using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows;

namespace BlockGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!IsAdministrator())
            {
                RunAsAdmin();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Путь к файлу hosts
                string filePath = @"C:\Windows\system32\drivers\etc\hosts";

                // Удаление файла, если он существует
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Создание записи
                string content = @"127.0.0.1 tlauncher.org
127.0.0.1 minecraft.net
127.0.0.1 epicgames.com
127.0.0.1 steamcommunity.com
127.0.0.1 gog.com
127.0.0.1 origin.com
127.0.0.1 uplay.ubisoft.com
127.0.0.1 battle.net
127.0.0.1 roblox.com
127.0.0.1 leagueoflegends.com
127.0.0.1 valorant.com
127.0.0.1 fortnite.com
127.0.0.1 pubg.com
127.0.0.1 dota2.com
127.0.0.1 worldofwarcraft.com
127.0.0.1 overwatch.com
127.0.0.1 diablo3.com
127.0.0.1 pathofexile.com
127.0.0.1 warframe.com
127.0.0.1 runescape.com
127.0.0.1 store.steampowered.com
127.0.0.1 ea.com
127.0.0.1 blizzard.com";

                // Создание нового файла и запись в него
                File.WriteAllText(filePath, content + Environment.NewLine);

                MessageBox.Show("Файл успешно обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
