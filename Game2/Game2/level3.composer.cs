// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Game2
{
    partial class level3
    {
        ImageBox ImageBox_1;
        Label lblHighscoreText;
        Label lblScore;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            ImageBox_1 = new ImageBox();
            ImageBox_1.Name = "ImageBox_1";
            lblHighscoreText = new Label();
            lblHighscoreText.Name = "lblHighscoreText";
            lblScore = new Label();
            lblScore.Name = "lblScore";

            // level3
            this.BackgroundColor = new UIColor(153f / 255f, 153f / 255f, 153f / 255f, 255f / 255f);
            this.Clip = true;
            this.AddChildLast(ImageBox_1);
            this.AddChildLast(lblHighscoreText);
            this.AddChildLast(lblScore);

            // ImageBox_1
            ImageBox_1.Image = null;
            ImageBox_1.ImageScaleType = ImageScaleType.Center;

            // lblHighscoreText
            lblHighscoreText.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblHighscoreText.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
            lblHighscoreText.TextTrimming = TextTrimming.Character;
            lblHighscoreText.LineBreak = LineBreak.Character;
            lblHighscoreText.HorizontalAlignment = HorizontalAlignment.Center;

            // lblScore
            lblScore.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            lblScore.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            lblScore.LineBreak = LineBreak.Character;
            lblScore.HorizontalAlignment = HorizontalAlignment.Center;

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.SetSize(315, 600);
                    this.Anchors = Anchors.None;

                    ImageBox_1.SetPosition(0, 0);
                    ImageBox_1.SetSize(200, 200);
                    ImageBox_1.Anchors = Anchors.None;
                    ImageBox_1.Visible = true;

                    lblHighscoreText.SetPosition(404, 63);
                    lblHighscoreText.SetSize(214, 36);
                    lblHighscoreText.Anchors = Anchors.None;
                    lblHighscoreText.Visible = true;

                    lblScore.SetPosition(404, 63);
                    lblScore.SetSize(214, 36);
                    lblScore.Anchors = Anchors.None;
                    lblScore.Visible = true;

                    break;

                default:
                    this.SetSize(600, 315);
                    this.Anchors = Anchors.None;

                    ImageBox_1.SetPosition(12, 54);
                    ImageBox_1.SetSize(439, 206);
                    ImageBox_1.Anchors = Anchors.None;
                    ImageBox_1.Visible = true;

                    lblHighscoreText.SetPosition(454, 121);
                    lblHighscoreText.SetSize(133, 36);
                    lblHighscoreText.Anchors = Anchors.None;
                    lblHighscoreText.Visible = true;

                    lblScore.SetPosition(454, 158);
                    lblScore.SetSize(133, 36);
                    lblScore.Anchors = Anchors.None;
                    lblScore.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            lblHighscoreText.Text = "Highscore";

            lblScore.Text = "#0000";
        }

        public void InitializeDefaultEffect()
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        public void StartDefaultEffect()
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
