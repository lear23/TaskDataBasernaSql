

using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;

namespace TaskDataBaseSql.Services;

public class ContactService
{
    private readonly ContactRepo _contactRepo;

    public ContactService(ContactRepo contactRepo)
    {
        _contactRepo = contactRepo;
    }

    public ContactEntity CreateContact(string email, string phoneNumber ="")
    {
        try
        {
            var contactEntity = _contactRepo.Get(x => x.Email == email && x.PhoneNumber == phoneNumber );
            if (contactEntity == null)
            {
                {
                    contactEntity = _contactRepo.Create(new ContactEntity
                    {
                      Email = email,
                      PhoneNumber = phoneNumber
                    });
                }
            }
            return contactEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateContactService :: " + ex.Message); }
        return null!;
    }
    public ContactEntity GetContactByName(string email, string phoneNumber )
    {
        try
        {
            var contactEntity = _contactRepo.Get(x => x.Email == email && x.PhoneNumber == phoneNumber );
            return contactEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetContactService :: " + ex.Message); }
        return null!;

    }

    public ContactEntity GetContactById(int id)
    {
        try
        {
            var contactEntity = _contactRepo.Get(x => x.Id == id);
            return contactEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdContactService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<ContactEntity> GetAllcontacts()
    {
        try
        {
            var contacts = _contactRepo.GetAll();
            return contacts;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllContactsService :: " + ex.Message); }
        return null!;
    }


    public ContactEntity UpdateContact(ContactEntity contactEntity)
    {
        try
        {
            var updateContact = _contactRepo.Update(x => x.Id == contactEntity.Id, contactEntity);
            return updateContact;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateContactService :: " + ex.Message); }
        return null!;
    }

    //public void DeleteContact(int id)
    //{
    //    try
    //    {
    //        _contactRepo.Delete(x => x.Id == id);

    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteContactService :: " + ex.Message); }

    //}


    public bool DeleteContact(Expression<Func<ContactEntity, bool>> expression)
    {
        try
        {
            var result = _contactRepo.Delete(expression);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteAddressService :: " + ex.Message); }
        return false;

    }


}
