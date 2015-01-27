

 function UpgradePackage(type,PackageModel) {
        $('#upgradeMessage').html('You cannot access  ' + type + '  Settings page in the SoCXO '+PackageModel+' account, please  Upgrade for more options');
        $("#uidemo-modals-alerts-info").modal("show");
    }