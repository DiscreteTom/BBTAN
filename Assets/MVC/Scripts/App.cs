using System.Collections;
using System.Collections.Generic;
using BBTAN.MVC.Model;
using DT.General;
using UnityEngine;

namespace BBTAN.MVC {
  public class App : MonoBehaviour {
    UIModel uiModel;
    UIController ui;

    void Start() {
      // init
      this.uiModel = new UIModel();
      this.ui = new UIController();

      // inject
      this.ui.Inject(uiModel);
    }

    void Update() {

    }
  }
}
