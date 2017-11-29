using Android.App;
using Android.Widget;
using Android.OS;
using Android;
using Android.Content;
using Android.Net;

[assembly:UsesPermission(Manifest.Permission.CallPhone)]
[assembly:UsesPermission(Android.Content.PM.PackageManager.FeatureTelephony)]
namespace Droid_fone
{
    [Activity(Label = "Droid_fone", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    { EditText editText;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            editText = FindViewById<EditText>(Resource.Id.editText);
            Button btnChamada = FindViewById<Button>(Resource.Id.fazerChamada);

            if (!PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureTelephony))
            {
                Toast.MakeText(this, "O dispositivo não suporta este recurso.", ToastLength.Short);
                return;
            }


            btnChamada.Click += BtnChamada_Click;
            
           
        }

        private void BtnChamada_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + editText.Text));
            StartActivity(intent);
            
            
        }
    }
}

