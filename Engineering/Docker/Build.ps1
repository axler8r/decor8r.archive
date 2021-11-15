$PRODUCT="decor8r"
$MAJOR=(Get-Date).Year
$MINOR=(Get-Date).DayOfYear
$CHUNK=-join ((48..57) + (65..90) + (97..122) | Get-Random -Count 7 | % {[char]$_})
docker build --tag "${PRODUCT}:${MAJOR}.${MINOR}.${CHUNK}" .

