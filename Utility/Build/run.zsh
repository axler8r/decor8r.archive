#!/usr/bin/env zsh

$("${DECOR8R_CLI}" decorate terminal --width="${COLUMNS}" --path="${(%):-%~}")

