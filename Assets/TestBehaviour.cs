using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Dependencies;
using UnityEngine;

public class TestBehaviour : DependentMonoBehaviour
{
    private GameDataService _gameDataService;
    public override void RegisterDependencies(IDependenciesProvider dependenciesProvider)
    {
        dependenciesProvider.RegisterSingleDependency(this);
    }

    public override void ResolveDependencies(IDependenciesProvider dependenciesProvider)
    {
        _gameDataService = dependenciesProvider.GetSingle<GameDataService>();
    }

    private void Update()
    {
        _gameDataService.SetResourceAmount(Time.deltaTime, Resource.Wood);
    }
}
