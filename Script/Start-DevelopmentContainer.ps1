$originalPolicy=Get-ExecutionPolicy
if ($originalPolicy -ne "Bypass") {
    Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
}

docker start decor8r.net

$currentPolicy=Get-ExecutionPolicy
if ($currentPolicy -ne $originalPolicy) {
    Set-ExecutionPolicy -Scope Process -ExecutionPolicy $originalPolicy
}
