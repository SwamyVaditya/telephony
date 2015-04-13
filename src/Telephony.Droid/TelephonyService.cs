﻿using System;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;


namespace Telephony
{
    public class TelephonyService : ITelephonyService
    {
        public TelephonyService()
        {
            
        }

        public Task ComposeEmail(Email email)
        {
            try
            {
                
                var intent = new Intent(Intent.ActionSend);
            
                intent.PutExtra(Intent.ExtraEmail, email.To.ToArray());
                intent.PutExtra(Intent.ExtraCc, email.Cc.ToArray());
                intent.PutExtra(Intent.ExtraBcc, email.Bcc.ToArray());

                intent.PutExtra(Intent.ExtraTitle, email.Subject ?? string.Empty);
            
                if (email.IsHTML)
                {
                    intent.PutExtra(Intent.ExtraText, Android.Text.Html.FromHtml(email.Body));
                }
                else
                {
                    intent.PutExtra(Intent.ExtraText, email.Body ?? string.Empty);
                }
            
                intent.SetType("message/rfc822");
            
                return null;
                //this.StartActivity(intent);
//            Device.StartActivity(intent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task ComposeSMS(string recipient, string message = null)
        {
            try
            {
                var uri = Android.Net.Uri.Parse(String.Format("smsto:{0}", recipient));
                var intent = new Intent(Intent.ActionSendto, uri);
                intent.PutExtra("sms_body", message ?? string.Empty);
                //            StartActivity(smsIntent);
                
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task MakeVideoCall(string recipient, string displayName = null)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task MakePhoneCall(string recipient, string displayName = null)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ComposeEmailFeatureEnabled
        {
            get
            {
                return true;
            }
        }

        public bool ComposeSMSFeatureEnabled
        {
            get
            {
                return true;
            }
        }

        public bool MakeVideoCallFeatureEnabled
        {
            get
            {
                return true;
            }
        }

        public bool MakePhoneCallFeatureEnabled
        {
            get
            {
                return true;
            }
        }
    }
}

