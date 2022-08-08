# Inventory module
## procurement Fields:{
### procurement header:
    {
        id
        refNo
        date
        attachments
    },
### procurement items:
    {
       id
       name
       type
       unitMeasure
       quantity
       totalQuantity
       explanation
       procurementId
    }
};
## Notify Fields:{
### Notify header:
    {
        id
        description
        attachments
    },
### notify items:
    {
       id
       type
       name
       quantity
       notifiesId
    }
};
## Item Fields:
{
-id
-name
-description
-type [Accessories,Belts,pipes,Motors Machine,etc...]
-price
-quantity
-unit [box,pcs,kilo,meter,etc...]
};
## Category of Asset:
{
* [Fixed-materials/fixed assets]
  furniture
  computers
  heavy equipment
  vehicles etc...
* [Fixed-none-fixed-materials]
* [None-fixed-materials]
  };
## Inventory fields:{
### Inventory:header
    {
       id
       itemNoInExpenditureRegister
       noOfEntryInTheRegisterOfIncomingGoods
       storeNo
       shelfNo
       donor
    },
### Inventory items:
    {
       id
       itemDescription
       model
       serialNo
       type
       quantity
       availability
       unitPrice
       totalPrice
       inventoriesId
    }
};
## Fixed-asset request and return:{
### Request asset:header
    {
        id
        department
        letterNumber
        orderPerson
        recipientPerson
        donorPerson
    },
### Request asset items:
    {
        id
        name
        assetType
        unitMeasurement
        officeNumber
        examination
    }
};

## Fixed Assets Transfer Form(FATF):{
## Transfer asset:header
    {
          id
          reasonOfTransferOfTheAsset
          signatureOfTransfer
          signatureOfRecipient
          observer
          headerOfFAM
          dateOfTransfer
### Asset transferred from:
    {
       name
       premises
       department
       buildingNo
       roomNo
       userNo
    },
### Asset transferred to:
    {
       name
       premises
       department
       buildingNo
       roomNo
       userNo
    },
    },
## Transfer asset items:
      {
         id
         name
         description
         pin(መለያ ቁጥር)
         serialNO(የፋብሪካ ቁጥር)
         unitMeasure
         price/cost
         remark
      }
};

# **Actors**
{
* MMD
* Other directorate
* Inventory division
* Fixed store man
* Non-fixed store man
* Fixed-non-fixed store man
  };
  };






