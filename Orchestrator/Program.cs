namespace Orchestrator
{
    class Program
    {
        static void Main(string[] args)
        {
            Maestro orch = new Maestro(1);
            orch.Connecter();
            orch.WaitCompletedConnexion();
            orch.Envoyer("Hello!");
            orch.Recevoir();
        }
    }
}