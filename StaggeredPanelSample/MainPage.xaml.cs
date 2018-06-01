using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Uwp;
using Newtonsoft.Json;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace StaggeredPanelSample
{
    public class SampleModel
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Category { get; set; }
    }
    public class SampleSource : IIncrementalSource<SampleModel>
    {

        private const string json =
            "[\r\n  {\r\n    \"Title\": \"A green sea turtle shows off its shell (© Sergi Garcia Fernandez/Minden Pictures)\",\r\n    \"Category\": \"Animal\",\r\n    \"Thumbnail\": \"http://az619822.vo.msecnd.net/files/CanaryIslandsTurtle_EN-US8274101746_1366x768.jpg\"\r\n  },\r\n    {\r\n    \"Title\": \"An elevated walkway in the Lujiazui district of Shanghai, China (© Mark Harris/Getty Images)\",\r\n    \"Category\": \"City\",\r\n    \"Thumbnail\": \"http://az619822.vo.msecnd.net/files/ShanghaiElevatedWalkway_EN-US8623422930_1366x768.jpg\"\r\n  },\r\n  {\r\n    \"Title\": \"Striped skunk kit smelling a wildflower (© Tim Fitzharris/Minden Pictures)\",\r\n    \"Category\": \"Animal\",\r\n    \"Thumbnail\": \"http://az619822.vo.msecnd.net/files/SkunkKit_EN-US10705950046_1366x768.jpg\"\r\n  },\r\n  {\r\n    \"Title\": \"Fox kits playing in the Rocky Mountain foothills near Cascade, Montana (© Jason Savage/Tandem Stills + Motion)\",\r\n    \"Category\": \"Animal\",\r\n    \"Thumbnail\": \"http://az619519.vo.msecnd.net/files/RockyMtFox_EN-US11902018005_1366x768.jpg\"\r\n  },\r\n  {\r\n    \"Title\": \"Burano, in the Venetian Lagoon, Italy (© Digitaler Lumpensammler/Getty Images)\",\r\n    \"Category\": \"City\",\r\n    \"Thumbnail\": \"http://az608707.vo.msecnd.net/files/Burano_EN-US12610622868_1366x768.jpg\"\r\n  },\r\n  {\r\n    \"Title\": \"Galápagos sea lion and pup, Rábida Island, Galápagos Islands, Ecuador (© Pete Oxford/Minden Pictures)\",\r\n    \"Category\": \"Animal\",\r\n    \"Thumbnail\": \"http://az608707.vo.msecnd.net/files/SealionMom_EN-US13623871731_1366x768.jpg\"\r\n  },\r\n  {\r\n    \"Title\": \"Common kestrel hunting for rodents (© Bertie Gregory/Corbis)\",\r\n    \"Category\": \"Animal\",\r\n    \"Thumbnail\": \"http://az608707.vo.msecnd.net/files/Kestrel_EN-US10433052515_1366x768.jpg\"\r\n  }\r\n]";

        public async Task<IEnumerable<SampleModel>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Delay(1000, cancellationToken);
            return JsonConvert.DeserializeObject<List<SampleModel>>(json);
        }
    }

    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public IncrementalLoadingCollection<SampleSource, SampleModel> Source { get; set; } =
            new IncrementalLoadingCollection<SampleSource, SampleModel>();
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
