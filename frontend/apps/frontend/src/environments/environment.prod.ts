export const environment = {
  production: true,
  backend: document.location.origin.replace(/\/[\w-]+\.plugin/, '/plugin.backend'),
  secureBackend: document.location.origin.replace(/\/[\w-]+\.plugin/, '/plugin.secureBackend'),
  devToken: ''
};
