using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackDesertColor
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    readonly SpeechSynthesizer _speech = new SpeechSynthesizer();

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      _speech.SelectVoiceByHints(VoiceGender.Female, VoiceAge.NotSet, 0, new CultureInfo("zh-TW"));
      _speech.Volume = 100;
      _speech.Rate = -2;
    }

    private void Window_Closed(object sender, EventArgs e)
    {
      _speech.Dispose();
    }

    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Escape)
      {
        MyModel.BlueNum = 0;
        MyModel.RedNum = 0;
        MyModel.YellowNum = 0;
        MyModel.WhiteNum = 0;
      }
    }

    private void MyBlueButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
      {
        MyModel.BlueNum++;
        _speech.SpeakAsyncCancelAll();
        _speech.SpeakAsync($"藍{MyModel.BlueNum}");
      }
      else if (e.ChangedButton == MouseButton.Right && e.RightButton == MouseButtonState.Pressed)
      {
        MyModel.BlueNum--;
      }
    }

    private void MyRedButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
      {
        MyModel.RedNum++;
        _speech.SpeakAsyncCancelAll();
        _speech.SpeakAsync($"紅{MyModel.RedNum}");
      }
      else if (e.ChangedButton == MouseButton.Right && e.RightButton == MouseButtonState.Pressed)
      {
        MyModel.RedNum--;
      }
    }

    private void MyYellowButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
      {
        MyModel.YellowNum++;
        _speech.SpeakAsyncCancelAll();
        _speech.SpeakAsync($"黃{MyModel.YellowNum}");
      }
      else if (e.ChangedButton == MouseButton.Right && e.RightButton == MouseButtonState.Pressed)
      {
        MyModel.YellowNum--;
      }
    }

    private void MyWhiteButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
      {
        MyModel.WhiteNum++;
        _speech.SpeakAsyncCancelAll();
        _speech.SpeakAsync($"白{MyModel.WhiteNum}");
      }
      else if (e.ChangedButton == MouseButton.Right && e.RightButton == MouseButtonState.Pressed)
      {
        MyModel.WhiteNum--;
      }
    }
  }

  class MainWindowModel : INotifyPropertyChanged
  {
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    protected void SetField<T>(ref T field, T value, string propName)
    {
      if (!EqualityComparer<T>.Default.Equals(field, value))
      {
        field = value;
        OnPropertyChanged(propName);
      }
    }
    #endregion

    int _blueNum = 0;
    public int BlueNum
    {
      get => _blueNum;
      set => SetField(ref _blueNum, Math.Max(value, 0), "BlueNum");
    }

    int _redNum = 0;
    public int RedNum
    {
      get => _redNum;
      set => SetField(ref _redNum, Math.Max(value, 0), "RedNum");
    }

    int _yellowNum = 0;
    public int YellowNum
    {
      get => _yellowNum;
      set => SetField(ref _yellowNum, Math.Max(value, 0), "YellowNum");
    }

    int _whiteNum = 0;
    public int WhiteNum
    {
      get => _whiteNum;
      set => SetField(ref _whiteNum, Math.Max(value, 0), "WhiteNum");
    }
  }
}
