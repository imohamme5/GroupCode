// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Game2
{
    partial class LevelSelect
    {
        Button btnLeft;
        Button btnRight;
        Button btnPlay;
        PagePanel pnlLevels;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            btnLeft = new Button();
            btnLeft.Name = "btnLeft";
            btnRight = new Button();
            btnRight.Name = "btnRight";
            btnPlay = new Button();
            btnPlay.Name = "btnPlay";
            pnlLevels = new PagePanel();
            pnlLevels.Name = "pnlLevels";

            // LevelSelect
            this.RootWidget.AddChildLast(btnLeft);
            this.RootWidget.AddChildLast(btnRight);
            this.RootWidget.AddChildLast(btnPlay);
            this.RootWidget.AddChildLast(pnlLevels);
            

            // Button_1
            btnLeft.IconImage = null;

            // btnRight
            btnRight.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            btnRight.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);

            // btnPlay
//            btnPlay.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
//            btnPlay.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);

            // pagePanel
            pnlLevels.AddPage(new level1());
            pnlLevels.AddPage(new level2());
            pnlLevels.AddPage(new level3());

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    btnLeft.SetPosition(0, 0);
                    btnLeft.SetSize(214, 56);
                    btnLeft.Anchors = Anchors.None;
                    btnLeft.Visible = true;

                    btnRight.SetPosition(0, 0);
                    btnRight.SetSize(214, 56);
                    btnRight.Anchors = Anchors.None;
                    btnRight.Visible = true;

                    btnPlay.SetPosition(179, 380);
                    btnPlay.SetSize(214, 56);
                    btnPlay.Anchors = Anchors.None;
                    btnPlay.Visible = true;
					
					
//					btnPlay.ButtonAction += (sender, e) => 
//					{
//					SceneManager.Instance.SendSceneToFront(new LevelScene(), SceneManager.SceneTransitionType.SolidFade, 0.0f);
//					
//            		};
				
				
                    pnlLevels.SetPosition(38, 0);
                    pnlLevels.SetSize(854, 400);
                    pnlLevels.Anchors = Anchors.None;
                    pnlLevels.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    btnLeft.SetPosition(0, 0);
                    btnLeft.SetSize(150, 544);
                    btnLeft.Anchors = Anchors.None;
                    btnLeft.Visible = true;

                    btnRight.SetPosition(810, 0);
                    btnRight.SetSize(150, 544);
                    btnRight.Anchors = Anchors.None;
                    btnRight.Visible = true;

                    btnPlay.SetPosition(179, 366);
                    btnPlay.SetSize(602, 143);
                    btnPlay.Anchors = Anchors.None;
                    btnPlay.Visible = true;
					
					

                    pnlLevels.SetPosition(179, 25);
                    pnlLevels.SetSize(602, 315);
                    pnlLevels.Anchors = Anchors.None;
                    pnlLevels.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            btnPlay.Text = "Play!";
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}
