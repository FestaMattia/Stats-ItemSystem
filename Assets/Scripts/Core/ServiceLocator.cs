using System;
using System.Collections.Generic;
using UnityEngine;
// Instance of service locator that contains a list of all registered services.
// TODO: make a bootstrap scene and avoid Singleton pattern. Dependency injection instead?
namespace Core
{
    public class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator Instance { get; private set; }

        private readonly Dictionary<Type, object> _services = new();

        private void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        /// <summary>
        /// Registers a service instance of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public void Register<T>(T service) where T : class
            => _services[typeof(T)] = service;
        /// <summary>
        /// Gets a registered service of type T. Throws if not found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T Get<T>() where T : class
            => _services.TryGetValue(typeof(T), out var s)
                ? (T)s
                : throw new InvalidOperationException($"{typeof(T).Name} not registered.");
    }
}