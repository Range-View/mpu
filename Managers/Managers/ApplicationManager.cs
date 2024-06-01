namespace Managers
{
    public class ApplicationManager
    {
        private UIManager uiManager;

        public ApplicationManager()
        {
            uiManager = new UIManager();

            Initialize();
        }

        private void Initialize()
        {
            //uiManager.Initialize();
        }

        public void Run()
        {
            bool shouldRender = true; // Replace later with actual stopping condition
            while (shouldRender)
            {
                uiManager.Update();
                Thread.Sleep(33); //30 FPS
            }
        }

        public void Shutdown()
        {
            //uiManager.Shutdown();
        }
    }
}
