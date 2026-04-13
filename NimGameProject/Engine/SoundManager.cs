using NimGameProject.GameLogic;
using NimGameProject.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace NimGameProject.Engine
{
    public class SoundManager
    {
        private static SoundPlayer sound_win = new SoundPlayer(Resources.sound_win);
        private static SoundPlayer sound_select = new SoundPlayer(Resources.sound_select);
        private static SoundPlayer sound_switch = new SoundPlayer(Resources.sound_switch);
        private static SoundPlayer sound_nom = new SoundPlayer(Resources.sound_nom);

        private static WindowsMediaPlayer themePlayer = new WindowsMediaPlayer();
        private static WindowsMediaPlayer winPlayer = new WindowsMediaPlayer();
        public static bool SoundOn { get; private set; }
        private static bool isThemePlaying = false;

        // gọi 1 lần để đồng bộ với config luôn
        public static void Init(GameConfig config)
        {
            SoundOn = config.SoundOn;
        }
        public static void UpdateConfig(GameConfig config)
        {
            SoundOn = config.SoundOn;

            if (!SoundOn)
                StopSoundTheme();
            else
                PlaySoundTheme();
        }

        private static void Play(SoundPlayer sound)
        {
            if(!SoundOn) return;

            sound.Play();
        }

        
        public static void PlaySoundSelect() => Play(sound_select);
        public static void PlaySoundNom() => Play(sound_nom);
        public static void PlaySoundSwitch() => Play(sound_switch);

        public static void PlaySoundWin()
        {
            string path = Path.Combine(Application.StartupPath, "Sounds", "sound_win.wav");
            winPlayer.URL = path;
            winPlayer.controls.play();
        }

        public static void PlaySoundTheme()
        {
            if(!SoundOn) return;
            if (isThemePlaying) return;

            string path = Path.Combine(Application.StartupPath, "Sounds", "sound_theme.wav");
            themePlayer.URL = path;
            themePlayer.settings.setMode("loop", true);
            //themePlayer.settings.volume = 10;
            themePlayer.controls.play();

            isThemePlaying = true;
        }

        public static void StopSoundTheme() {
            themePlayer.controls.stop();
            isThemePlaying = false;
        }
    }
}
