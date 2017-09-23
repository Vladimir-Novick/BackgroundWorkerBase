using System.ComponentModel;

////////////////////////////////////////////////////////////////////////////
//	Copyright 2010 : Vladimir Novick    https://www.linkedin.com/in/vladimirnovick/  
//
//         https://github.com/Vladimir-Novick/FileSystemWatcher
//
//    NO WARRANTIES ARE EXTENDED. USE AT YOUR OWN RISK. 
//
// To contact the author with suggestions or comments, use  :vlad.novick@gmail.com
//
////////////////////////////////////////////////////////////////////////////

namespace SGcombo.Tasks
{
    /// <summary>
    ///  Use a Background Worker
    /// </summary>
    public class BackgroundWorkerBase
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        public BackgroundWorkerBase()
        {
            backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged +=  new ProgressChangedEventHandler(OnProgressChanged);
            backgroundWorker.WorkerSupportsCancellation = true;

        }

        /// <summary>
        ///   Worker process changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          
        }

        public virtual void OnCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                OnCompleted(sender, e);

            }
            finally
            {
                backgroundWorker.Dispose();
            }
        }

        /// <summary>
        ///  Worker process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void DoWork(object sender, DoWorkEventArgs e)
        {


        }

        /// <summary>
        ///    send status backgrownd worker
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="useState"></param>
        public void ReportProgress(int progress,object useState)
        {
            backgroundWorker.ReportProgress(progress, useState);
        }

        /// <summary>
        ///  send status
        /// </summary>
        /// <param name="progress"></param>
        public void ReportProgress(int progress)
        {
            backgroundWorker.ReportProgress(progress);
        }



        /// <summary>
        ///   Run worker process with arguments
        /// </summary>
        /// <param name="arguments"></param>
        public void RunWorkerAsync(object arguments)
        {
            backgroundWorker.RunWorkerAsync(arguments);
        }



        /// <summary>
        ///  Run worker process
        /// </summary>
        public void RunWorkerAsync()
        {
            backgroundWorker.RunWorkerAsync();
        }

    }
}
