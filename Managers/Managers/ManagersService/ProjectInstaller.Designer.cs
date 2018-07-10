namespace ManagersService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ManagersserviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.ManagersServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // ManagersserviceProcessInstaller
            // 
            this.ManagersserviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.ManagersserviceProcessInstaller.Password = null;
            this.ManagersserviceProcessInstaller.Username = null;
            this.ManagersserviceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // ManagersServiceInstaller
            // 
            this.ManagersServiceInstaller.ServiceName = "ManagersService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ManagersserviceProcessInstaller,
            this.ManagersServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ManagersserviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller ManagersServiceInstaller;
    }
}