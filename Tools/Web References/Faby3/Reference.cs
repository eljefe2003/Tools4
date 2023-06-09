﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Tools.Faby3 {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IAppTools", Namespace="http://tempuri.org/")]
    public partial class AppTools : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback dailyTasks21OperationCompleted;
        
        private System.Threading.SendOrPostCallback blacklistOperationCompleted;
        
        private System.Threading.SendOrPostCallback reenvioOperationCompleted;
        
        private System.Threading.SendOrPostCallback storageTaskOperationCompleted;
        
        private System.Threading.SendOrPostCallback receptorOperationCompleted;
        
        private System.Threading.SendOrPostCallback dailyTasksOSEOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AppTools() {
            this.Url = global::Tools.Properties.Settings.Default.Tools_Faby3_AppTools;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event dailyTasks21CompletedEventHandler dailyTasks21Completed;
        
        /// <remarks/>
        public event blacklistCompletedEventHandler blacklistCompleted;
        
        /// <remarks/>
        public event reenvioCompletedEventHandler reenvioCompleted;
        
        /// <remarks/>
        public event storageTaskCompletedEventHandler storageTaskCompleted;
        
        /// <remarks/>
        public event receptorCompletedEventHandler receptorCompleted;
        
        /// <remarks/>
        public event dailyTasksOSECompletedEventHandler dailyTasksOSECompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IAppTools/dailyTasks21", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public serviceResponse dailyTasks21([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string token, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string ruc, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string documento, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string fecha, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string mantis, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string opcion, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", IsNullable=true)] byte[] archivo) {
            object[] results = this.Invoke("dailyTasks21", new object[] {
                        token,
                        ruc,
                        documento,
                        fecha,
                        mantis,
                        opcion,
                        archivo});
            return ((serviceResponse)(results[0]));
        }
        
        /// <remarks/>
        public void dailyTasks21Async(string token, string ruc, string documento, string fecha, string mantis, string opcion, byte[] archivo) {
            this.dailyTasks21Async(token, ruc, documento, fecha, mantis, opcion, archivo, null);
        }
        
        /// <remarks/>
        public void dailyTasks21Async(string token, string ruc, string documento, string fecha, string mantis, string opcion, byte[] archivo, object userState) {
            if ((this.dailyTasks21OperationCompleted == null)) {
                this.dailyTasks21OperationCompleted = new System.Threading.SendOrPostCallback(this.OndailyTasks21OperationCompleted);
            }
            this.InvokeAsync("dailyTasks21", new object[] {
                        token,
                        ruc,
                        documento,
                        fecha,
                        mantis,
                        opcion,
                        archivo}, this.dailyTasks21OperationCompleted, userState);
        }
        
        private void OndailyTasks21OperationCompleted(object arg) {
            if ((this.dailyTasks21Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.dailyTasks21Completed(this, new dailyTasks21CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IAppTools/blacklist", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public serviceResponse blacklist([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string token, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string correo, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string opcion) {
            object[] results = this.Invoke("blacklist", new object[] {
                        token,
                        correo,
                        opcion});
            return ((serviceResponse)(results[0]));
        }
        
        /// <remarks/>
        public void blacklistAsync(string token, string correo, string opcion) {
            this.blacklistAsync(token, correo, opcion, null);
        }
        
        /// <remarks/>
        public void blacklistAsync(string token, string correo, string opcion, object userState) {
            if ((this.blacklistOperationCompleted == null)) {
                this.blacklistOperationCompleted = new System.Threading.SendOrPostCallback(this.OnblacklistOperationCompleted);
            }
            this.InvokeAsync("blacklist", new object[] {
                        token,
                        correo,
                        opcion}, this.blacklistOperationCompleted, userState);
        }
        
        private void OnblacklistOperationCompleted(object arg) {
            if ((this.blacklistCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.blacklistCompleted(this, new blacklistCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IAppTools/reenvio", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public serviceResponse reenvio([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string token, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string documento, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string ubl, bool reenviar, [System.Xml.Serialization.XmlIgnoreAttribute()] bool reenviarSpecified, bool renombrarxml, [System.Xml.Serialization.XmlIgnoreAttribute()] bool renombrarxmlSpecified, bool renombrarcdr, [System.Xml.Serialization.XmlIgnoreAttribute()] bool renombrarcdrSpecified, bool regenerar, [System.Xml.Serialization.XmlIgnoreAttribute()] bool regenerarSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string mantis, bool firmar, [System.Xml.Serialization.XmlIgnoreAttribute()] bool firmarSpecified) {
            object[] results = this.Invoke("reenvio", new object[] {
                        token,
                        documento,
                        ubl,
                        reenviar,
                        reenviarSpecified,
                        renombrarxml,
                        renombrarxmlSpecified,
                        renombrarcdr,
                        renombrarcdrSpecified,
                        regenerar,
                        regenerarSpecified,
                        mantis,
                        firmar,
                        firmarSpecified});
            return ((serviceResponse)(results[0]));
        }
        
        /// <remarks/>
        public void reenvioAsync(string token, string documento, string ubl, bool reenviar, bool reenviarSpecified, bool renombrarxml, bool renombrarxmlSpecified, bool renombrarcdr, bool renombrarcdrSpecified, bool regenerar, bool regenerarSpecified, string mantis, bool firmar, bool firmarSpecified) {
            this.reenvioAsync(token, documento, ubl, reenviar, reenviarSpecified, renombrarxml, renombrarxmlSpecified, renombrarcdr, renombrarcdrSpecified, regenerar, regenerarSpecified, mantis, firmar, firmarSpecified, null);
        }
        
        /// <remarks/>
        public void reenvioAsync(string token, string documento, string ubl, bool reenviar, bool reenviarSpecified, bool renombrarxml, bool renombrarxmlSpecified, bool renombrarcdr, bool renombrarcdrSpecified, bool regenerar, bool regenerarSpecified, string mantis, bool firmar, bool firmarSpecified, object userState) {
            if ((this.reenvioOperationCompleted == null)) {
                this.reenvioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnreenvioOperationCompleted);
            }
            this.InvokeAsync("reenvio", new object[] {
                        token,
                        documento,
                        ubl,
                        reenviar,
                        reenviarSpecified,
                        renombrarxml,
                        renombrarxmlSpecified,
                        renombrarcdr,
                        renombrarcdrSpecified,
                        regenerar,
                        regenerarSpecified,
                        mantis,
                        firmar,
                        firmarSpecified}, this.reenvioOperationCompleted, userState);
        }
        
        private void OnreenvioOperationCompleted(object arg) {
            if ((this.reenvioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.reenvioCompleted(this, new reenvioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IAppTools/storageTask", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public serviceResponse storageTask([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string token, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string fileName, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", IsNullable=true)] byte[] file, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string mantis, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string option) {
            object[] results = this.Invoke("storageTask", new object[] {
                        token,
                        fileName,
                        file,
                        mantis,
                        option});
            return ((serviceResponse)(results[0]));
        }
        
        /// <remarks/>
        public void storageTaskAsync(string token, string fileName, byte[] file, string mantis, string option) {
            this.storageTaskAsync(token, fileName, file, mantis, option, null);
        }
        
        /// <remarks/>
        public void storageTaskAsync(string token, string fileName, byte[] file, string mantis, string option, object userState) {
            if ((this.storageTaskOperationCompleted == null)) {
                this.storageTaskOperationCompleted = new System.Threading.SendOrPostCallback(this.OnstorageTaskOperationCompleted);
            }
            this.InvokeAsync("storageTask", new object[] {
                        token,
                        fileName,
                        file,
                        mantis,
                        option}, this.storageTaskOperationCompleted, userState);
        }
        
        private void OnstorageTaskOperationCompleted(object arg) {
            if ((this.storageTaskCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.storageTaskCompleted(this, new storageTaskCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IAppTools/receptor", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public serviceResponse receptor([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string token, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string documento, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string fechaEmision) {
            object[] results = this.Invoke("receptor", new object[] {
                        token,
                        documento,
                        fechaEmision});
            return ((serviceResponse)(results[0]));
        }
        
        /// <remarks/>
        public void receptorAsync(string token, string documento, string fechaEmision) {
            this.receptorAsync(token, documento, fechaEmision, null);
        }
        
        /// <remarks/>
        public void receptorAsync(string token, string documento, string fechaEmision, object userState) {
            if ((this.receptorOperationCompleted == null)) {
                this.receptorOperationCompleted = new System.Threading.SendOrPostCallback(this.OnreceptorOperationCompleted);
            }
            this.InvokeAsync("receptor", new object[] {
                        token,
                        documento,
                        fechaEmision}, this.receptorOperationCompleted, userState);
        }
        
        private void OnreceptorOperationCompleted(object arg) {
            if ((this.receptorCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.receptorCompleted(this, new receptorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IAppTools/dailyTasksOSE", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public serviceResponse dailyTasksOSE([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string token, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string mantis, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string opcion, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string ruc, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string rucsupplier, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string tipoDocumento, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string numeracion_identificador) {
            object[] results = this.Invoke("dailyTasksOSE", new object[] {
                        token,
                        mantis,
                        opcion,
                        ruc,
                        rucsupplier,
                        tipoDocumento,
                        numeracion_identificador});
            return ((serviceResponse)(results[0]));
        }
        
        /// <remarks/>
        public void dailyTasksOSEAsync(string token, string mantis, string opcion, string ruc, string rucsupplier, string tipoDocumento, string numeracion_identificador) {
            this.dailyTasksOSEAsync(token, mantis, opcion, ruc, rucsupplier, tipoDocumento, numeracion_identificador, null);
        }
        
        /// <remarks/>
        public void dailyTasksOSEAsync(string token, string mantis, string opcion, string ruc, string rucsupplier, string tipoDocumento, string numeracion_identificador, object userState) {
            if ((this.dailyTasksOSEOperationCompleted == null)) {
                this.dailyTasksOSEOperationCompleted = new System.Threading.SendOrPostCallback(this.OndailyTasksOSEOperationCompleted);
            }
            this.InvokeAsync("dailyTasksOSE", new object[] {
                        token,
                        mantis,
                        opcion,
                        ruc,
                        rucsupplier,
                        tipoDocumento,
                        numeracion_identificador}, this.dailyTasksOSEOperationCompleted, userState);
        }
        
        private void OndailyTasksOSEOperationCompleted(object arg) {
            if ((this.dailyTasksOSECompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.dailyTasksOSECompleted(this, new dailyTasksOSECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/Tools")]
    public partial class serviceResponse {
        
        private int errorCodeField;
        
        private bool errorCodeFieldSpecified;
        
        private string errorMessageField;
        
        private bool processField;
        
        private bool processFieldSpecified;
        
        /// <remarks/>
        public int errorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool errorCodeSpecified {
            get {
                return this.errorCodeFieldSpecified;
            }
            set {
                this.errorCodeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string errorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
            }
        }
        
        /// <remarks/>
        public bool process {
            get {
                return this.processField;
            }
            set {
                this.processField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool processSpecified {
            get {
                return this.processFieldSpecified;
            }
            set {
                this.processFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void dailyTasks21CompletedEventHandler(object sender, dailyTasks21CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class dailyTasks21CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal dailyTasks21CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public serviceResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((serviceResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void blacklistCompletedEventHandler(object sender, blacklistCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class blacklistCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal blacklistCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public serviceResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((serviceResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void reenvioCompletedEventHandler(object sender, reenvioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class reenvioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal reenvioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public serviceResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((serviceResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void storageTaskCompletedEventHandler(object sender, storageTaskCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class storageTaskCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal storageTaskCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public serviceResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((serviceResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void receptorCompletedEventHandler(object sender, receptorCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class receptorCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal receptorCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public serviceResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((serviceResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void dailyTasksOSECompletedEventHandler(object sender, dailyTasksOSECompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class dailyTasksOSECompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal dailyTasksOSECompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public serviceResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((serviceResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591