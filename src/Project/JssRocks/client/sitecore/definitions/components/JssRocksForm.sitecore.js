import { SitecoreIcon } from '@sitecore-jss/sitecore-jss-manifest';

export default function(manifest) {
  manifest.addComponent({
    name: 'JssRocksForm',
    displayName: 'JSS Rocks Form',
    icon: SitecoreIcon.Atom2,
    addAntiForgeryToken: true
  });
}
