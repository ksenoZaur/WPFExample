using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class Emplyee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Emplyee[] Manager { get; set; }
    }

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
//            ContentRendered += Window_ContentRendeDoSync       }
        }

//        private void Window_ContentRendered()
//        {
//            BackgroundWorker worker = new BackgroundWorkerDoAsync         worker.WorkerReportsProgress = true;
//            worker.DoWork += worker_DoWork;
//            worker.ProgressChanged += worker_ProgressChanged;
//
//            worker.RunWorkerAsync();
//            worker.RunWorkerCompleted += setEnable;
//        }

//        public async void start(object sender, EventArgs eventArgs)
//        {
//            
//            btn1.IsEnabled = false;   
//            Window_ContentRendered(); 
//        }
//
//        public void setEnable(object sender, EventArgs eventArgs)
//        {
//            btn1.IsEnabled = true;  
//        }
//            
//        void worker_DoWork(object sender, DoWorkEventArgs e)
//        {
//            for(int i = 0; i < 100; i++)
//            {
//                (sender as BackgroundWorker).ReportProgress(i+1);
//                Thread.Sleep(100);
//            }
//        }
//        
//        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
//        {
//            try
//            {
//                pg_status.Value = e.ProgressPercentage;
//            }
//            catch (Exception exception)
//            {
//                Console.WriteLine(exception);
//                throw;
//            }
//        }


        public void DoSync(object sender, RoutedEventArgs e)
        {
            int max = 10000;
            progBar.Value = 0;
            lbResults.Items.Clear();
            int result = 0;
            
            for(int i = 0; i < max; i++)
            {
                if(i % 42 == 0)
                {
                    lbResults.Items.Add(i);
                    result++;
                }
                System.Threading.Thread.Sleep(1);
                progBar.Value = Convert.ToInt32(((double)i / max) * 100);
            }
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + result);
        }

        public void DoAsync(object sender, RoutedEventArgs e)
        {
            // Сбрасываем прогресс
            progBar.Value = 0;
            // Очищаем список результата
            lbResults.Items.Clear();
            
            // Создаем новый поток, для выполнения задачи
            BackgroundWorker worker = new BackgroundWorker();
            //... с возможностью отслеживать процесс
            worker.WorkerReportsProgress = true;
            // Указываем задачу, которая должна выполняться в о отдельном потоке
            worker.DoWork += worker_DoWork;
            // указываем обработчик события, вызываемого при изменении прогресса задчи
            worker.ProgressChanged += worker_ProgressChanged;
            // действие, выполняемое по завершении задачи
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            // Запускаем
            worker.RunWorkerAsync(10000);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + e.Result);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progBar.Value = e.ProgressPercentage;
            if(e.UserState != null)
                lbResults.Items.Add(e.UserState);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int)e.Argument;
            int result = 0;
            for(int i = 0; i < max; i++)
            {
                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if(i % 42 == 0)
                {
                    result++;
                    (sender as BackgroundWorker).ReportProgress(progressPercentage,i);
                }
                else
                {
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                }
                System.Threading.Thread.Sleep(1);

            }
            e.Result = result;
        }
    }
}