$originalPolicy=Get-ExecutionPolicy
if ($originalPolicy -ne "Bypass") {
    Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
}

docker start seq

$currentPolicy=Get-ExecutionPolicy
if ($currentPolicy -ne $originalPolicy) {
    Set-ExecutionPolicy -Scope Process -ExecutionPolicy $originalPolicy
}
