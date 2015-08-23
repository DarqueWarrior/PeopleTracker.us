[cmdletbinding(SupportsShouldProcess = $true)]
param($publishScript, $buildNumber, $packOutput, $webApiBaseUrl)

'==== Publish Settings ====' | Write-Verbose
'Build Number: {0}' -f $buildNumber | Write-Verbose
'Package output path: {0}' -f $packOutput | Write-Verbose
'Web Api Base Url: {0}' -f $webApiBaseUrl | Write-Verbose
'Publish Script File: {0}' -f $publishScript | Write-Verbose

$profileName = (Split-Path $publishScript -Leaf).Replace('-publish.ps1', '')
$pubxmlFile = '{0}.pubxml' -f $profileName

'Pubxml File: {0}' -f $pubxmlFile | Write-Verbose

$publishProperties = @{}

if($buildNumber)
{
    Write-Verbose 'Ading build number to publish properites'
    $publishProperties.DockerTag = "$buildNumber"
}

if($webApiBaseUrl)
{
    Write-Verbose 'Ading Web Api Base Url to publish properites'
    $publishProperties.WebApiBaseUrl = "$webApiBaseUrl"
}

& "$publishScript" $publishProperties $packOutput $pubxmlFile