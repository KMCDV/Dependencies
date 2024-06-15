using System;
using System.Collections.Generic;
using System.Linq;
using Dependencies;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameDataService : BaseService
    {
        public Dictionary<Resource, ResourceData> ResourceDatas = new();

        public EventHandler<ResourceAmountUpdatedEventArgs> ResourceAmountUpdated;

        public override void RegisterDependencies(IDependenciesProvider dependenciesProvider)
        {
            dependenciesProvider.RegisterSingleDependency(this);
            ResourceDatas = Resources.LoadAll<ResourceData>("Data").ToDictionary(resourceData => resourceData.Resource, resourceData => resourceData);
        }

        public override void ResolveDependencies(IDependenciesProvider dependenciesProvider)
        {
            
        }

        public ResourceData GetResourceData(Resource resource)
        {
            return ResourceDatas.TryGetValue(resource, out ResourceData data) ? data : null;
        }

        public void SetResourceAmount(float amount, Resource resource)
        {
           if(ResourceDatas.ContainsKey(resource) == false)
               return;
           ResourceDatas[resource].amount = amount;
           ResourceAmountUpdated?.Invoke(this, new ResourceAmountUpdatedEventArgs
           {
               Resource = resource, 
               Amount = amount
           });
        }
    }

    public class ResourceAmountUpdatedEventArgs : EventArgs
    {
        public Resource Resource;
        public float Amount;
    }

    public enum Resource
    {
        Wood,
        Stone,
        Food
    }
}