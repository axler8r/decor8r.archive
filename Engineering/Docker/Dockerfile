FROM mcr.microsoft.com/dotnet/sdk:6.0

ENV             IN_DOCKER true
RUN             apt update --yes && \
                apt upgrade --yes && \
                apt install htop tree zsh zsh-doc --yes && \
                useradd --create-home --shell /usr/bin/zsh decor8r && \
                touch /home/decor8r/.zshrc && \
                chown -R decor8r:decor8r /home/decor8r/.zshrc
USER            decor8r
WORKDIR         /home/decor8r
ENTRYPOINT      ["/usr/bin/zsh"]

