using System;
using Dependencies;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestResolver : DependentMonoBehaviour
    {
        private TestBehaviour _behaviour;
        private GameDataService _gameDataService;
        public override void RegisterDependencies(IDependenciesProvider dependenciesProvider)
        {
        }

        public override void ResolveDependencies(IDependenciesProvider dependenciesProvider)
        {
            _behaviour = dependenciesProvider.GetSingle<TestBehaviour>();
            if(_behaviour != null)
                Debug.Log("git");
            _gameDataService = dependenciesProvider.GetSingle<GameDataService>();
            if(_gameDataService != null)
                Debug.Log("Service is git");

            _gameDataService.ResourceAmountUpdated += ResourceAmountUpdated;
        }

        private void ResourceAmountUpdated(object sender, ResourceAmountUpdatedEventArgs e)
        {
            Debug.Log("Resource Updated");
            if (e is { Resource: Resource.Wood })
            {
                Debug.Log($"Wood is {e.Amount}");
            }
        }

        private void OnDestroy()
        {
            _gameDataService.ResourceAmountUpdated -= ResourceAmountUpdated;
        }
    }
}