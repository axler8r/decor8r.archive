#!/usr/bin/env zsh

# TODO: Define PRODUCT and VERSION
HASH=$(cat /dev/urandom | tr -dc '[[:alnum:]]' | head -c 7)
if [[ -x $(which docker) ]] {
	docker build --tag "${PRODUCT:-decor8r}:${VERSION:-$(date +f %y%m%d)}-${HASH}"
}

