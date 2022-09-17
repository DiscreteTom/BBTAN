using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT.General {
  public class Game {
    List<MockBehaviour> objects;
    Dictionary<Type, MockBehaviour> dict;

    public void OnAwake() {
      this.objects.ForEach(o => o.Init());
    }
    public void OnStart() {
      this.objects.ForEach(o => o.Connect());
    }
    public void OnUpdate() {
      this.objects.ForEach(o => o.Update());
    }

    public void Register<T>(T obj) where T : MockBehaviour {
      this.objects.Add(obj);
      this.dict.Add(typeof(T), obj);
    }
    public void Deregister<T>(T obj) where T : MockBehaviour {
      this.objects.Remove(obj);
      this.dict.Remove(typeof(T));
    }

    public T Get<T>() where T : MockBehaviour {
      this.dict.TryGetValue(typeof(T), out var ret);
      return ret as T;
    }
  }
}
