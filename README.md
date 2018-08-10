# Discord Service Hook Consumer for VSTS
Adds a consumer for discord in the VSTS Service Hooks to take advantage of Discord Webhooks

Discord already supports integration for slack. Instead of creating an entirely new set of webhooks for updates, just append /slack to then end of your API call. VSTS already supports slack integration so instead of creating a middle tier function to change the object, we can just let Discord handle this for us with the /slack option.
