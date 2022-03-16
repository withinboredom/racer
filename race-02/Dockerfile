FROM php:8-cli-alpine AS cli
COPY --from=mlocati/php-extension-installer /usr/bin/install-php-extensions /usr/local/bin/
RUN apk add git nghttp2
RUN install-php-extensions apcu gettext curl intl zip pcntl sodium gmp opcache sysvmsg ev memcached igbinary mysqli @composer && mkdir -p /app
COPY opcache.ini /tmp/opcache.ini
RUN mv "$PHP_INI_DIR/php.ini-production" "$PHP_INI_DIR/php.ini"
RUN cat /tmp/opcache.ini >> $PHP_INI_DIR/php.ini
COPY index.php /index.php
COPY file/file.bin /file/file.bin
CMD ["php","/index.php"]
